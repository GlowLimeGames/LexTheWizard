/*
* Author: Isaiah Mann
* Description: Util class to complement Unity's PlayerPrefs class
*/
using UnityEngine;
using System.Collections;

public static class PlayerPrefsUtil {

	/*
	 * PlayerPrefs has no bool class
	 * This wrapped provides that functionality
	*/
	public static bool GetBool (string key) {
		return IntToBool(PlayerPrefs.GetInt(key, 0));
	}

	public static void SetBool (string key, bool value) {
		PlayerPrefs.SetInt(
			key, 
			BoolToInt(value)
		);
	}

	static bool IntToBool (int value) {
		return ! (value == 0);
	}

	static int BoolToInt (bool value) {
		return value ? 1 : 0;
	}
}