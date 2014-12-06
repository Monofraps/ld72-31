using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			CoinController coinController = collision.gameObject.GetComponent<CoinController>();
			coinController.collectChoin();
			
			GameObject.Destroy(gameObject);
		}
		
	}
}
