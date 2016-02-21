using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// variable to track days passed
	public int days;
	// variable to track current time of the day
	public DayTime currDayTime;
	// variable to track current terrain
	public string currTerrain;

	// variables to track family members status
	public bool isFatherAlive;
	public bool isSisterAlive;
	public bool isGrandmaAlive;

	// win conditions varibles
	int winPoints;
	int winGold;
	int winSalvage;

	void Start () {
		days = 0;
		currDayTime = DayTime.Dawn;
		//currTerrain

		winPoints = 30;
		winGold = 25;
		winSalvage = 40;

		isFatherAlive = true;
		isSisterAlive = true;
		isGrandmaAlive = true;
	}

/*
	void Update () {

	}
*/

	/*
	 * Turn mechanics
	 */

	public void Turn() {
		//CardInfo card = Deck.DrawCard ();
		//...
	}

	/*
	 * Phases of day mechanics
	 */

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

	/*
	 * Win mechanics
	 */

	// raise winning condition for points
	public void raisePoints (int amount) {
		winPoints += amount;
	}

	// raise winning condition for gold
	public void raiseGold (int amount) {
		winGold += amount;
	}

	// raise winning condition for salvage
	public void raiseSalvage (int amount) {
		winSalvage += amount;
	}

	// check for winning conditions
	public bool Win () {
		// gets player's stats
		int[] stats = Player.player.GetStats();

		if (stats [0] >= winPoints || stats [1] >= winGold || stats [2] >= winSalvage) {
			return true;
		} 
		else {
			return false;
		}
		// need to add swamp king condition if it goes to final game
	}

}
