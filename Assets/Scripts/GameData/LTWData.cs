/*
 * Author: Isaiah Mann
 * Description: Abstract superclass for data in Lex The Wizard
 */

using SimpleJSON;

[System.Serializable]
public abstract class LTWData {

	protected string[] JSONToStringArray (JSONArray json) {
		string[] result = new string[json.Count];
		for (int i = 0; i < result.Length; i++) {
			result[i] = json[i];
		}
		return result;
	}

}
