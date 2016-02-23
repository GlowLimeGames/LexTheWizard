/*
 * Author: Isaiah Mann
 * Description: Used to parse card info from a CSV File
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class CardUtil {
	const string _cardArtFilePathInResources = "Cards/";
	const int _numberOfCardInfoParameters = 11;
	const int _headerOffset = 1;
	/*
	 * Columns correspond to info:
	
			string title, string terrain, string daytime, string cardType, int points, int gold, int salvage, int homeValue, Sprite art, string desc1, string desc2
	*/

	public static CardInfo[] ReadCardInfoFromFile (TextAsset textAsCSV) {

		string[] textByLine = textAsCSV.text.Split('\n');

		CardInfo[] allCards = new CardInfo[textByLine.Length - _headerOffset];

		for (int i = _headerOffset; i < allCards.Length; i++) {

			allCards[i] = ParseCardInfoFromCSVLine(textByLine[i]);

		}

		return allCards;
	}

	public static CardInfo ParseCardInfoFromCSVLine (string lineFromCSV) {

		string[] parameters = lineFromCSV.Split(',');
		if (parameters.Length == _numberOfCardInfoParameters) {
			
			return new CardInfo (
				parameters[0],
				parameters[1],
				parameters[2],
				parameters[3],
				int.Parse(parameters[4]),
				int.Parse(parameters[5]),
				int.Parse(parameters[6]),
				int.Parse(parameters[7]),
				LoadCardSprite(parameters[8]),
				parameters[9],
				parameters[10]
			);

		} else {

			Debug.LogError("Incorrect number of parameters to generate card info: " + parameters.Length);
			return null;

		}

	}

	public static Sprite LoadCardSprite (string cardSpriteNameInResources) {
		return Resources.Load<Sprite>(_cardArtFilePathInResources + cardSpriteNameInResources);
	}

	public static void TestModifiedSplit () {
		Debug.Log(splitStringWithEscapeQuoteMarks("this,is,\"a,test\"", ','));
	}

	static string [] splitStringWithEscapeQuoteMarks (string lineFromCSV, char splitChar) {

		List<string> paramemters = new List<string>();

		int lastIndexAdded = 0;
		bool insideQuoteMarks = false;

		for (int i = 0; i < lineFromCSV.Length; i++) {
			if (lineFromCSV[i] == splitChar && !insideQuoteMarks) {
				paramemters.Add( 
					lineFromCSV.Substring(lastIndexAdded, i - lastIndexAdded - 1)
				);

				lastIndexAdded = i-1;
			} else if (isQuoteMark(lineFromCSV[i])) {
				insideQuoteMarks = !insideQuoteMarks;
			}
		}

		return paramemters.ToArray();
	}

	static bool isQuoteMark (char testForQuoteMark) {
		return testForQuoteMark == '"' || testForQuoteMark == '\'';
	}

}
