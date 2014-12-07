using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float rotationOffset;

    private Rigidbody2D playerRigidbody2d;
    private Animator animator;
    private PlayerWiggle playerWiggle;
    private Vector3 teleportPos;
    private float rotation;
    private Vector2 previousVelocity;
    public GameObject shieldObject;
    public bool IsControlInverted { get; set; }
    private bool shield;
    public bool Shield
    {
        set
        {
            shield = value;
            shieldObject.SetActive(shield);
        }
        get
        {
            return shield;
        }
    }

    public static PlayerControler FindInScene()
    {
        GameObject player = GameObject.Find("Snowman");
        if (player == null)
        {
            throw new UnityException("No player found in the scene.");
        }
        PlayerControler playerControler = player.GetComponent<PlayerControler>();
        if (playerControler == null)
        {
            throw new UnityException("No PlayerControler attached to Player Gameobject.");
        }
        return playerControler;

    }

    public void Teleport(Vector3 pos)
    {
        teleportPos = pos;
        animator.SetTrigger("Portal Entered");
        Invoke("TeleportAnimCallback", 2.0f); // Animation lasts 2 seconds;
    }

    private void TeleportAnimCallback()
    {
        transform.position = teleportPos;
        teleportPos = Vector3.zero;
    }


    // Use this for initialization
    void Start()
    {
        playerRigidbody2d = rigidbody2D;
        animator = GetComponentInChildren<Animator>();
        playerWiggle = GetComponentInChildren<PlayerWiggle>();
        Shield = false;
    }



    
    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = new Vector2(0, 0);

        velocity.x = Input.GetAxis("Horizontal") * speed * (IsControlInverted ? -1 : 1);
        velocity.y = Input.GetAxis("Vertical") * speed * (IsControlInverted ? -1 : 1);

        if (velocity.magnitude == 0 && previousVelocity.magnitude != 0)
        {
            float sign = Mathf.Sign(Vector3.Dot(Vector3.forward, Vector3.Cross(Vector3.up, previousVelocity)));
            rotation = Vector3.Angle(Vector3.up, previousVelocity)*sign;
        }
        else
        {
            float sign = Mathf.Sign(Vector3.Dot(Vector3.forward, Vector3.Cross(Vector3.up, velocity)));
            rotation = Vector3.Angle(Vector3.up, velocity)*sign;
            previousVelocity = velocity;
        }

        playerRigidbody2d.velocity = velocity;
        transform.rotation = Quaternion.Euler(new Vector3(0,0, rotation + playerWiggle.rotationOffset));


        animator.SetFloat("Velocity", Mathf.Abs(velocity.x + velocity.y));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(Shield)
            {
                // Got lucky this time. Return... for now muhahahaha
                return;
            }
            // DIEEEEEEEEEE
            GameController.Instance.RestartLevel();
        }
    }
}
