/*
 * Author(s): Tim Ng, Noah Cohen, Sienna Cornish, Isaiah Mann
 * Description: Updates the background display of the game in accordance with the terrain type and time of day
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateBackgroundState : MonoBehaviour {
    public static UpdateBackgroundState INSTANCE;
    public Image background;

	// Time of day is arranged by the GameController.DayTime enum 
	/* Enum Value --> Sprite Key:
	 * Dawn --> Morning
	 * Dusk --> Afternoon
	 * Night --> Night
	 */
	[SerializeField]
	Sprite[] caveBackgrounds;
	[SerializeField]
	Sprite[] forestBackgrounds;
	[SerializeField]
	Sprite[] hillBackgrounds;
	[SerializeField]
	Sprite[] swampBackgrounds;

	// Stores all the terrain types in a jagged array
	Sprite[][] terrainBackgrounds;

	void Awake() {
        if (INSTANCE == null) {
            INSTANCE = this;
			InitBackgrounds();
        }
    }

	void InitBackgrounds () {
		// Arrays are organized based on the GameController.Terrain enum
		terrainBackgrounds = new Sprite[][]{
			swampBackgrounds,
			hillBackgrounds,
			forestBackgrounds,
			caveBackgrounds
		};
	}

    void OnEnable() {
		Fungus.Flowchart.BroadcastFungusMessage("UpdateBackgroundStateStart");
    }

	// Update is only called once per turn (this MonoBehaviour is disabled at all other times)
	void Update () {
		UpdateBackground();
		// Necessary for game logic
		GameController.INSTANCE.NextState();
	}

    public void UpdateBackground () {
		// Casting enum values to integers for direct indexing into the array
		int terrainIndex = (int) GameController.INSTANCE.currentTerrain;
		int timeOfDayIndex = (int) GameController.INSTANCE.currentDayTime;
		try {
			background.sprite = terrainBackgrounds[terrainIndex][timeOfDayIndex];
		} catch (System.Exception e) {
			// Handle an errors, presumabmly accounting for index out of range exceptions
			Debug.LogErrorFormat("Error: {0}, [{1}, {2}] is not a valid index", e, terrainIndex, timeOfDayIndex);
		}
	}
}