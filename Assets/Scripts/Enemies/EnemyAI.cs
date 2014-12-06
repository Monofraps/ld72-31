using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
		public Vector2 velocity;
		public float speed = 10;
		private Rigidbody2D playerRigidbody2d;
			
	enum movingDirections
		{
				up,
				down,
				left,
				right
	};
	private movingDirections movingDirection;
		// Use this for initialization
		void Start ()
		{
				playerRigidbody2d = rigidbody2D;
				velocity.x = speed * Time.deltaTime;
				movingDirection = movingDirections.right;
		}
	
		// Update is called once per frame
		void Update ()
		{
		Debug.Log (movingDirection);
		if (movingDirection == movingDirections.right) {
			velocity.x = speed;
			velocity.y = 0;
		}
		if (movingDirection == movingDirections.up) {
			velocity.x = 0;
			velocity.y = speed;
		}
		if (movingDirection == movingDirections.left) {
			velocity.x = speed * -1;
			velocity.y = 0;

		}
		if (movingDirection == movingDirections.down) {
			velocity.y = speed * -1;
			velocity.x = 0;
		}
		
		playerRigidbody2d.velocity = velocity;
	}
	
	void OnCollisionEnter2D (Collision2D collision)
		{
				velocity = playerRigidbody2d.velocity;		
				Debug.Log ("hit");
				if (collision.gameObject.CompareTag ("Player")) {
						//Hit on Player
				}
				if (collision.gameObject.CompareTag ("Wall")) {
						Debug.Log ("Wall");			
						if (movingDirection == movingDirections.right) {
								movingDirection = movingDirections.up;
				Debug.Log(movingDirection);
			}
						else if (movingDirection == movingDirections.up) {
								movingDirection = movingDirections.left;
						}
						else if (movingDirection == movingDirections.left) {
								movingDirection = movingDirections.down;
						}
						else if (movingDirection == movingDirections.down) {
								movingDirection = movingDirections.right;
						}
			
				}

		}
}
