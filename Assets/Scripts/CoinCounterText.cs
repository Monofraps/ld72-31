using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinCounterText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		setCointCounter (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setCointCounter( int count){
		GetComponent<Text> ().text = "Coins: " + count;
	}
}
