/*
 * Author: Isaiah Mann
 * Description: Utility methods to assist with using strings
 * All methods are static
 */


using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public static class StringUtil {

	public static string RepeatString (string stringToRepeat, int repeatCount) {
		string finalString = stringToRepeat;

		for (int i = 1; i < repeatCount; i++) {
			finalString += stringToRepeat;
		}

		return finalString;
	}

	public static string AddSquareBrackets (string source) {
		return "[" + source + "]";
	}

	public static string RemoveSquareBrackets (string source) {
		return source.Replace
			("[", string.Empty).Replace(
				"]", string.Empty);	
	}

	public static char LastChar (string source) {
		return source[source.Length-1];
	}

	// Source: http://www.dotnetperls.com/word-count
	/// <summary>
	/// Count words with Regex.
	/// </summary>
	public static int CountWords(string s)
	{
		MatchCollection collection = Regex.Matches(s, @"[\S]+");
		return collection.Count;
	}

	// Checks if the text contains a substring of the stringToFind (but not the full stringToFind)
	public static bool ContainsPartialSubstring (string text, string stringToFind, out string subStringFound) {
		subStringFound = null;

		if (!text.Contains(stringToFind)) {
			for (int i = stringToFind.Length - 1; i > 0; i--) {
				if (text.Contains(stringToFind.Substring(0, i))) {
					subStringFound = stringToFind.Substring(0, i);
					return true;
				}
			}

			return false;

		} else {
			return false;
		}
	}

	public static bool ContainsPartialSubstring (string text, string stringToFind) { 
		string overloadLoopHole;

		return ContainsPartialSubstring(text, stringToFind, out overloadLoopHole);
	}

	// Checks if a string equals any string with an array of list of string params
	public static bool OrEquals (string target, params string[] compares) {
		bool foundEquivalent = false;
		foreach (string compare in compares) {
			foundEquivalent |= target.Equals(compare);
		}
		return foundEquivalent;
	}
}