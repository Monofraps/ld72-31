using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {
	private int choinsCount = 0;
	public CoinCounterText choinText;

	public void collectChoin(){
		choinsCount++;
		choinText.setCointCounter (choinsCount);
		}

}
