using UnityEngine;
using System.Collections;

public class ShieldPowerupTutorial : MonoBehaviour {
	public TutorialText powerupText;
	public TutorialText shieldText;

	void OnDisable() {
		powerupText.Hide ();
		shieldText.Show ();
	}
}
