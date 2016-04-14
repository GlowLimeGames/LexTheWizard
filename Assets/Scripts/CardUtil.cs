/*
 * Author: Isaiah Mann
 * Description: Used to parse card info from a CSV File
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class CardUtil {
	
	const string _cardArtFilePathInResources = "Cards/";

	// Specifies where the CSV files are saved (do not include file extension)
	const string _defaultPlayerDeck = "Decks/PlayerMVPDeck";
	const string _defaultAIDeck = "Decks/AIMVPDeck";

	// Corresponds to columns in CSV's
	const int _numberOfPlayerCardInfoParameters = 12;
	const int _numberOfAICardInfoParameters = 7;

	const int _csvHeaderOffset = 1;

	// Player Deck:
	static CardInfo[] _playerDeck;

	public static CardInfo[] PlayerDeck {
		get {
			if (_playerDeck == null) {
				
				_playerDeck = CardUtil.ReadPlayerCardInfoFromFile(_defaultPlayerDeck);
				return _playerDeck;

			} else {
				
				return _playerDeck;

			}
		}
	}

	// AI Deck:
	static CardInfo[] _aiDeck;

	public static CardInfo[] AIDeck {
		get {

			if (_aiDeck == null) {

				_aiDeck = CardUtil.ReadAICardInfoFromFile(_defaultAIDeck);
				return _aiDeck;

			} else {
				
				return _aiDeck;

			}
		}
	}

	// Overloaded method to load the CSV file from Resources
	public static CardInfo[] ReadPlayerCardInfoFromFile (string filePathInResources) {
		return ReadPlayerCardInfoFromFile (
			Resources.Load<TextAsset>(filePathInResources)
		);
	}

	// Overloaded method to load the CSV file from Resources
	public static CardInfo[] ReadAICardInfoFromFile (string filePathInResources) {
		return ReadAICardInfoFromFile (
			Resources.Load<TextAsset>(filePathInResources)
		);
	}
		
	public static CardInfo[] ReadPlayerCardInfoFromFile (TextAsset textAsCSV) {

		string[] textByLine = textAsCSV.text.Split('\n');

		CardInfo[] allCards = new CardInfo[textByLine.Length - _csvHeaderOffset];

		for (int i = _csvHeaderOffset; i < allCards.Length + _csvHeaderOffset; i++) {

			allCards[i - _csvHeaderOffset] = ParsePlayerCardInfoFromCSVLine(textByLine[i]);

		}

		return allCards;
	}

	public static CardInfo[] ReadAICardInfoFromFile (TextAsset textAsCSV) {

		string[] textByLine = textAsCSV.text.Split('\n');

		CardInfo[] allCards = new CardInfo[textByLine.Length - _csvHeaderOffset];

		for (int i = _csvHeaderOffset; i < allCards.Length + _csvHeaderOffset; i++) {

			allCards[i - _csvHeaderOffset] = ParseAICardInfoFromCSVLine(textByLine[i]);

		}
			
		return allCards;
	}

	public static CardInfo ParsePlayerCardInfoFromCSVLine (string lineFromCSV) {

		string[] parameters = splitStringWithEscapeQuoteMarks(lineFromCSV, ',');

		if (parameters.Length == _numberOfPlayerCardInfoParameters) {
			
			return new CardInfo (
				parameters[0], // Title
				ParseTerrains(parameters[1]), // Terrain
				parameters[2], // Daytime
				int.Parse(parameters[3]), // Week
				parameters[4], // Card Type
				int.Parse(parameters[5]), // Point
				int.Parse(parameters[6]), // Gold
				int.Parse(parameters[7]), // Salvage
				int.Parse(parameters[8]), // Home Value
				LoadCardSprite(parameters[9]), // Sprite
				parameters[10], // Description
				parameters[11] // Effects
			);

		} else {

			Debug.Log (parameters [0]);
			Debug.LogError("Incorrect number of parameters to generate card info: " + parameters.Length);
			return null;

		}

	}

	public static CardInfo ParseAICardInfoFromCSVLine (string lineFromCSV) {
	
		string[] parameters = splitStringWithEscapeQuoteMarks(lineFromCSV, ',');

		if (parameters.Length == _numberOfAICardInfoParameters) {
				return new CardInfo (
					parameters[0], // Title
					ParseTerrains(parameters[1]), // Terrain
					parameters[2], // Card Type
					int.Parse(parameters[3]), // Week
					parameters[4], // Description
					int.Parse(parameters[5]), // AI Value
					parameters[6] // Effects
				);

		} else {

			Debug.LogError("Incorrect number of parameters to generate card info: " + parameters.Length + " in card " + parameters[0]);
			return null;

		}

	}

    /*
     * This function parses strings like "Swamp/Forest/Hills" into arrays of the corresponding Lands
     * It looks up these terrains in GameController
     * 
     * "Any" will return an array of all the terrains.
     * 
     * In the case of something like "Caves/Any"
     * the first terrain ("Caves" in this example) becomes the default 
     * and is stored in the first index of the returned array.
     * 
     * The default terrain determines which card background sprite to use.
     */
    public static Land[] ParseTerrains(string terrainString)
    {
        Land[] terrains = null;
        GameController gameController = GameController.gameController;
        Land[] allTerrains = gameController.terrains;
        string[] terrainNames = terrainString.Split('/');
		if (ArrayUtil.Contains(terrainNames, "Any"))
        { // If card can be played on any terrain
            terrains = new Land[allTerrains.Length];
            if (terrainNames[0] == "Any")
            { // If the default terrain is not specified (which would normally be at the 0 index)
                terrains = allTerrains; // Include all terrains
            }
            else
            { // If a default terrain is specified
                Land defaultTerrain = gameController.GetTerrainByName(terrainNames[0]);
                terrains[0] = defaultTerrain; // Set default terrain as first index of terrains array
                int nextIndex = 1;
                // Add remaining terrains
                for (int i = 0; i < allTerrains.Length; i++)
                {
                    Land currentTerrain = allTerrains[i];
                    if (currentTerrain != defaultTerrain)
                    { // If the current terrain is not the default terrain (and therefore already in the array)
                        terrains[nextIndex] = currentTerrain; // Add the terrain to the array
                        nextIndex++;
                    }
                }
            }
        }
        else
        { // If the card can not be played on any terrain
            terrains = new Land[terrainNames.Length];
            for (int i = 0; i < terrainNames.Length; i++)
            { // For all terrain names specified
                terrains[i] = gameController.GetTerrainByName(terrainNames[i]); // Look up the terrain and store it in the array
            }
        }
        return terrains;
    }

	public static Sprite LoadCardSprite (string cardSpriteNameInResources) {
		return Resources.Load<Sprite>(_cardArtFilePathInResources + cardSpriteNameInResources);
	}

	// Google Drive generated CSV files use quote marks to surround cells that contain commas within them
	static string [] splitStringWithEscapeQuoteMarks (string lineFromCSV, char splitChar) {

		List<string> paramemters = new List<string>();

		int lastIndexAdded = 0;
		bool insideQuoteMarks = false;

		for (int i = 0; i < lineFromCSV.Length; i++) {
			if (lineFromCSV[i] == splitChar && !insideQuoteMarks) {
				paramemters.Add( 
					removeQuoteMarksFromEnds (
						lineFromCSV.Substring(lastIndexAdded, i - lastIndexAdded)
					)
				);

				lastIndexAdded = i + 1;
			} else if (isQuoteMark(lineFromCSV[i])) {
				insideQuoteMarks = !insideQuoteMarks;
			}
		}

		// Adds the final string to the array of strings
		paramemters.Add(
			removeQuoteMarksFromEnds (
				lineFromCSV.Substring (
					lastIndexAdded, 
					lineFromCSV.Length - lastIndexAdded
				)
			)
		);

		return paramemters.ToArray();
	}

	// Tests for quote mark
	static bool isQuoteMark (char testForQuoteMark) {
		return testForQuoteMark == '"';
	}

	// Removes quote marks from either end of a string
	static string removeQuoteMarksFromEnds (string stringWithQuoteMarks) {
		return stringWithQuoteMarks.Trim('\"');
	}

}
