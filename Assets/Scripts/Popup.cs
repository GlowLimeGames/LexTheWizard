using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Popup : MonoBehaviour {

	Text messageText;
	Text dismissButtonText;
	Button dismissButton;

	void Start() {
		messageText = GetComponentsInChildren<Text>() [0];
		Button dismissButton = GetComponentInChildren<Button> ();
		dismissButtonText = dismissButton.GetComponentInChildren<Text> ();
		SetDismissButtonText (Tuning.tuning.defaultDismissButtonText);
	}

	public void SetText(string message) {
		messageText.text = message;
	}

	public void SetDismissButtonText(string text) {
		dismissButtonText.text = text;
	}

	public void Dimiss() {
		//SetDismissButtonText (Tuning.tuning.defaultDismissButtonText);
		gameObject.SetActive (false);
	}
}
