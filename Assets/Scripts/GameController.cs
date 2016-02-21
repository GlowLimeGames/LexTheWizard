using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// variable to track days passed
	public int days;
	// variable to track current time of the day
	public DayTime currDayTime;
	// variable to track current terrain
	public string currTerrain;

	//TODO Family status vars
	//TODO Win conditions. Check on return home.

	private gameState currState;
	public gameState[] previousTerrain = new gameState[6];

	void Start () {
		days = 0;
		currDayTime = DayTime.Dawn;

		//Initializes array of traversable terrain as the only current terrain
		currState.setTerrain (currTerrain);
		previousTerrain [0] = currState;
		for (int i = 1; i < previousTerrain.Length; i++) {
			previousTerrain [i] = null;
		}
	}

    /*
	void Update () {

	}
    */

	public void Turn() {
		//CardInfo card = Deck.DrawCard ();
		//...


		//WE SHOULD TRACK PHASES AND THIS IS WHERE WE CHECK CASES TO PERFORM THE CHANGES


		//TURN PROGRESSION:
		//1st Draw (Player and AI both draw)
		//Discard
		//Dawn(aka Action 1)
		//Afternoon(aka Action 2)
		//Dusk(aka Action 3)
		//2nd Draw (Player and AI both draw)
		//Check if current state has shelter

		//The move action updates the state.
	}

	// sets time to dawn and updates days passed
	public void SetDawn() {
		currDayTime = DayTime.Dawn;
		days++;
	}

	// sets time to afternoon
	public void SetAfternoon() {
		currDayTime = DayTime.Afternoon;
	}

	// sets time to dusk
	public void SetDusk() {
		currDayTime = DayTime.Dusk;
	}

	// sets time to night
	public void SetNight() {
		currDayTime = DayTime.Dawn;
	}

	// the possible phases of the day
	public enum DayTime {
		Dawn,
		Afternoon,
		Dusk,
		Night
	};

	//NOTE: May move below and associated code to more appropriate class.
	//Tracks the previous terrain type and whether Lex used a shelter there.
	//This is stored in an array in the parent class for Lex to access.
	private class gameState {
		private string terrainType;
		private bool shelter;

		public bool getShelter(){
			return shelter;
		}

		public string getTerrainType(){
			return terrainType;
		}

		public void setTerrain(string terrain){
			this.terrainType = terrain;
		}

		public void setShelter(bool shelterUsed){
			this.shelter = shelterUsed;
		}

	}
}
