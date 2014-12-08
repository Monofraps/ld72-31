using UnityEngine;
using System.Collections;

public class ShieldUsageTutorial : MonoBehaviour {
	public TutorialText useShieldText;
	public TutorialText next;

	void OnTriggerEnter2D() {
		useShieldText.Hide ();
		next.Show ();
	}
}
