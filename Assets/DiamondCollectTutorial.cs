using UnityEngine;
using System.Collections;

public class DiamondCollectTutorial : MonoBehaviour {
	public TutorialText diamondText;
	public TutorialText nextText;

	void OnDestroy() {
		diamondText.Hide ();
		nextText.Show ();
	}
}
