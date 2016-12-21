using UnityEngine;
using System.Collections;

[System.Serializable]
public class UIEventHandler {
	[SerializeField]
	UIAction action;

	[SerializeField]
	string[] triggers;

	public bool RespondsToTrigger (string trigger) {
		return StringUtil.OrEquals(trigger, this.triggers);
	}

	public void Execute (UIElement element) {
		action.Execute(element);
	}
}
