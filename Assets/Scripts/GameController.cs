using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// variable to track days passed
	public int days;
	// variable to track current time of the day
	public DayTime currDayTime;
	// variable to track current terrain
	public string currTerrain;

	void Start () {
		days = 0;
		currDayTime = DayTime.Dawn;
		//currTerrain
	}

	void Update () {

	}

	public void Turn() {
		//CardInfo card = Deck.DrawCard ();
		//...
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
}
