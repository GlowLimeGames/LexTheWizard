/*
 * Author(s): Isaiah Mann 
 * Description: A single event class that others can subscribe to and call events from
 * Currently relies on event names as strings
 * Event method can be overloaded to implement different event types
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class EventController {
	#region Static Initialization
	static bool _debug = false;

	static EventController () {
		Init();
	}

	static void Init() {
		if (_debug) {
			Debug.Log("Initializing Event Controller");
		}
	}
	#endregion

	public delegate void Action();

	#region Event Types
	public delegate void NamedEventAction (string nameOfEvent);
	public static event NamedEventAction OnNamedEvent;

	public delegate void NamedFloatAction (string valueKey, float key);
	public static event NamedFloatAction OnNamedFloatEvent;

    public delegate void AudioEventAction(AudioActionType actionType, AudioType audioType);
    public static event AudioEventAction OnAudioEvent;

	#endregion

	#region Event Calls
	public static void Event (string eventName) {
		if (OnNamedEvent != null) {
			OnNamedEvent(eventName);
		}
	}
		

	public static void Event (string valueKey, float value) {
		if (OnNamedFloatEvent != null) {
			OnNamedFloatEvent(valueKey, value);
		}
	}

    public static void Event(AudioActionType actionType, AudioType audioType) {
        if (OnAudioEvent != null) {
            OnAudioEvent(actionType, audioType);
        }
    }

	#endregion
}