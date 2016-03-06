using UnityEngine;
using System.Collections;

public static class AudioUtil {

	public static AudioActionType MuteActionFromBool (bool muted) {
		return muted ? AudioActionType.Mute : AudioActionType.Unmute;
	}

	public static bool MutedBoolFromAudioAction (AudioActionType actionType) {
		switch (actionType) {

		case AudioActionType.Mute:
			return true;

		case AudioActionType.Unmute:
			return false;

		default:
			throw new System.Collections.Generic.KeyNotFoundException();

		}
	}

	public static bool IsMuteAction (AudioActionType actionType) {
		return actionType == AudioActionType.Mute || actionType == AudioActionType.Unmute;
	}

	public static AudioType AudioTypeFromString (string audioType) {

		switch (audioType) {

		case "FX":
			return AudioType.FX;
		case "Music":
			return AudioType.Music;
		case "VO":
			return AudioType.VO;
		default:
			throw new System.Collections.Generic.KeyNotFoundException();
		}
	}

	public static bool IsMuted (AudioType audioType) {
		switch (audioType) {
		case AudioType.FX:
			return SettingsUtil.FXMuted;
		case AudioType.Music:
			return SettingsUtil.MusicMuted;
		default:
			throw new System.Collections.Generic.KeyNotFoundException();
		}
	}
}
