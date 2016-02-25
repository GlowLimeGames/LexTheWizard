using UnityEngine;
using System.Collections;

public static class FileUtil {

	public static string FileText (string path) {
		return convertQuotationMarks(
			Resources.Load<TextAsset>(path).text
		);
	}

	// JSON only accepts the standard quotation marks
	private static string convertQuotationMarks (string original) {
		char[] characters = original.ToCharArray();
		for (int i = 0; i < characters.Length; i++) {
			if (isIncorrectQuotationMark(characters[i])) {
				characters[i] = correctQuoatationMark();
			}
		}

		return new string(characters);

	}

	static bool isIncorrectQuotationMark (char character) {
		return (int) character == 8220 ||
			(int) character == 8221;
	}

	static char correctQuoatationMark () {
		return '"';
	}
}