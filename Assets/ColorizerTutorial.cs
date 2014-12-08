using UnityEngine;
using System.Collections;

public class ColorizerTutorial : MonoBehaviour {
	public TutorialText colorizerText;
	public TutorialText next;

	void OnTriggerEnter2D() {
		colorizerText.Hide ();
		next.Show ();
	}
}
