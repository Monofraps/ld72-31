using UnityEngine;
using System.Collections;

public class TutorialText : MonoBehaviour {
	public bool hideOnStartup;

	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = (SpriteRenderer)renderer;

		if (hideOnStartup) {
			Hide ();		
		}
	}

	public void Hide() {
		if (spriteRenderer) {
			spriteRenderer.color = new Color (0, 0, 0, 0);
		}
		if (collider2D) {
			collider2D.enabled = false;
		}
	}

	public void Show() {
		if (spriteRenderer) {
			spriteRenderer.color = new Color (1, 1, 1, 1);
		}

		if (collider2D) {
			collider2D.enabled = true;
		}
	}

	void OnDisable() {
		Hide ();
	}

	void OnDestroy() {
		Hide ();
	}
}
