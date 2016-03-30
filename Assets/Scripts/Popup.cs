using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Popup : MonoBehaviour {

	Text messageText;

	void Start() {
		messageText = GetComponentsInChildren<Text>() [0];
	}

	public void SetText(string message) {
		messageText.text = message;
	}

	public void Hide() {
		gameObject.SetActive (false);
	}
}
