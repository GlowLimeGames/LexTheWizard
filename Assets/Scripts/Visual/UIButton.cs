/*
 * Author(s): Isaiah Mann
 * Description: Describes a simple button class
 */

using UnityEngine;
using UnityEngine.UI;

public class UIButton : UIElement {
	protected Button button;
	protected Image buttonGraphic;
	protected MonoAction clickAction;
	protected Color selectedColor = Color.gray;
	protected Color deselectedColor = Color.white;

	public void SubscribeToClick (MonoAction action) {
		this.clickAction += action;
	}

	public void UnsubscribeFromClick (MonoAction action) {
		this.clickAction -= action;
	}

	public void UnsubscribeAllClickActions () {
		this.clickAction = null;
	}

	public void Select () {
		if (buttonGraphic) {
			buttonGraphic.color = selectedColor;
		}
	}

	public void Deselect () {
		if (buttonGraphic) {
			buttonGraphic.color = deselectedColor;
		}
	}

	public void ToggleInteractable (bool isInteractable) {
		button.interactable = isInteractable;
	}

	protected override void SetReferences () {
		base.SetReferences();
		button = GetComponent<Button>();
		buttonGraphic = GetComponent<Image>();
		button.onClick.AddListener(executeClick);
		setButtonColors();
	}

	void setButtonColors () {
		selectedColor = Color.Lerp(buttonGraphic.color, Color.gray, 0.5f);
		deselectedColor = buttonGraphic.color;
	}

	protected virtual void executeClick () {
		if (clickAction != null) {
			clickAction();
		}
	}
}
