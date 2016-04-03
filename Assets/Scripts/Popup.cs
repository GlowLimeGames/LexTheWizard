using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Popup : MonoBehaviour {

	Text messageText;

	void Start() {
		messageText = GetComponentsInChildren<Text>() [0];
	}

	public void SetText(string message) {
        if (messageText == null)
        {
            messageText = GetComponentsInChildren<Text>()[0];
        }
		messageText.text = message;
	}

	public void Hide() {
		gameObject.SetActive (false);
	}
}
