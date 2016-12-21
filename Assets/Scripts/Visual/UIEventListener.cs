/*
 * Author: Isaiah Mann
 * Description: Used to receive events
 */

using UnityEngine;
using System.Collections;

public class UIEventListener : MonoBehaviour {
	[SerializeField]
	UIEventHandler[] handlers;
	UIElement element;

	void Awake () {
		element = GetComponent<UIElement>();
		if (!element) {
			element = gameObject.AddComponent<UIElement>();
		}
		SubscribeEvents();
	}

	void OnDestroy () {
		UnsubscribeEvents();
	}

	void SubscribeEvents () {
		EventController.OnNamedEvent += HandleNamedEvent;
	}

	void UnsubscribeEvents () {
		EventController.OnNamedEvent -= HandleNamedEvent;
	}

	void HandleNamedEvent (string eventName) {
		foreach (UIEventHandler handler in handlers) {
			if (handler.RespondsToTrigger(eventName)) {
				handler.Execute(element);
			}
		}
	}
}
