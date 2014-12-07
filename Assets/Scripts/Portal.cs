using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;

    private bool IgnoreNextTriggerEnter{ get; set; }

    // Use this for initialization
    void Start()
    {
        IgnoreNextTriggerEnter = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IgnoreNextTriggerEnter)
        {
            IgnoreNextTriggerEnter = false;
            return;
        }
        if (other.tag == "Player")
        {
            if (linkedPortal)
            {
                linkedPortal.IgnoreNextTriggerEnter = true;

                other.GetComponent<PlayerControler>().Teleport(linkedPortal.transform.position);            
            }
        }
    }
}
