/*
 * Author(s): Isaiah Mann 
 * Description: Helper class to handle JSON objects
 */

using SimpleJSON;
using UnityEngine;
using System.Collections;

public static class JSONUtil {

	public static string[] GetStringArray (JSONArray stringArrayAsJSONArray) {
		string[] array = new string[stringArrayAsJSONArray.Count];

		for (int i = 0; i < array.Length; i++) {
			array[i] = stringArrayAsJSONArray[i];
		}

		return array;
	}
}
