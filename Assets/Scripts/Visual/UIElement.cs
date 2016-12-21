using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIElement : MonoBehaviour {
	Image image;
	Text text;

	[SerializeField]
	Sprite[] alternateSprites;
	public bool hasImage {
		get {
			return image != null;
		}
	}
	public bool hasText {
		get {
			return text != null;
		}
	}
	public bool hasAlternateSprites {
		get {
			return alternateSprites.Length > 0;
		}
	}


	void Awake () {
		AssignReferences();
	}

	void AssignReferences () {
		image = GetComponentInChildren<Image>();
		text = GetComponentInChildren<Text>();
	}

	public void Show () {
		gameObject.SetActive(true);
	}

	public void Hide () {
		gameObject.SetActive(false);
	}

	public void RandomSprite () {
		if (hasImage && hasAlternateSprites) {
			this.image.sprite = alternateSprites[Random.Range(0, alternateSprites.Length)];
		}
	}

	public void SetText (string text) {
		if (hasText) {
			this.text.text = text;
		}
	}
}
