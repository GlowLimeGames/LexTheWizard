using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class UIElement : MonoBehaviourExtended, IPointerDownHandler, IPointerUpHandler {
	protected InputController input;
	Image image;
	Text text;
	[SerializeField]
	protected bool blocksUIInput = false;
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

	protected override void SetReferences () {
		image = GetComponentInChildren<Image>();
		text = GetComponentInChildren<Text>();
	}

	protected override void FetchReferences () {
		input = InputController.Instance;
	}

	protected override void CleanupReferences () {
		// NOTHING
	}

	protected override void HandleNamedEvent (string eventName) {
		// NOTHING
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
		
	public virtual void OnPointerDown (PointerEventData pointerEvent) {
		if (blocksUIInput) {
			input.BlockUIInput();
		}
	}

	public virtual void OnPointerUp (PointerEventData pointerEvent) {
		if (blocksUIInput) {
			input.UnblockUIInput();
		}
	}
}
