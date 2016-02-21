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

	private CardGame cardGame;
	private Deck playerDeck;
	private Deck enemyDeck;

	private GameObject enemy;
	private CardPlayer player;

	private gameState currState;
	private gameState[] previousTerrain = new gameState[6];
	private int phase;

	void Start () {
		days = 0;
		currDayTime = DayTime.Dawn;


		cardGame = GetComponent<CardGame>();
		enemy = GameObject.FindWithTag("Enemy");
		playerDeck = cardGame.playerDeck;
		enemyDeck = cardGame.enemyDeck;

		//Initializes array of traversable terrain as the only current terrain
		currState.setTerrain (currTerrain);
		phase = 0;
		previousTerrain [0] = currState;
		for (int i = 1; i < previousTerrain.Length; i++) {
			previousTerrain [i] = null;
		}
	}

	public void Turn() {
		//CardInfo card = Deck.DrawCard ();
		//...

		//Temp var to reduce the number of calls  made to certain methods
		CardObject playedCard = null;

		//WE SHOULD TRACK PHASES AND THIS IS WHERE WE CHECK CASES TO PERFORM THE CHANGES
		//TURN PROGRESSION:

		switch(phase){
		//1st Draw (Player and AI both draw)
		case 0:			
			player.AddCardToHand (playerDeck.DrawCard ());
			enemy.AddCardToHand (enemyDeck.DrawCard ());
			//Cycles 0 to 5 to represent the phases.
			phase = (phase + 1) % 6;
			Turn ();
			break;

		//Dawn/Action 1
		case 1:			
			//TODO Update art to Dawn
			playedCard = enemy.selectCard ();
			if (playedCard != null) {
				enemy.PlayCard (playedCard);
			}

			phase = (phase + 1) % 6;
			SetAfternoon ();
			break;

		//Afternoon/Action 2
		case 2:			
			//Update art to Afternoon
			playedCard = enemy.GetComponent<EnemyBehavior>().selectCard ();
			if (playedCard != null) {
				enemy.PlayCard (playedCard);
			}
			phase = (phase + 1) % 6;
			SetDusk ();
			break;
		//Dusk/Action 3
		case 3:			
			//Update art to Dusk
			playedCard = enemy.selectCard ();
			if (playedCard != null) {
				enemy.PlayCard (playedCard);
			}
			phase = (phase + 1) % 6;
			SetNight ();
			break;

		//2nd draw phase
		case 4:			
			player.AddCardToHand (playerDeck.DrawCard ());
			enemy.AddCardToHand (enemyDeck.DrawCard ());
			phase = (phase + 1) % 6;
			Turn ();
			break;

		//Night/Action 4
		case 5:			
			//Update art to Night
			//Check if current state has shelter when enemy plays cards at night
			playedCard = enemy.selectCard ();
			if (playedCard != null) {
				enemy.PlayCard (playedCard);
			}
			//This time phase will loop back to 0
			phase = (phase + 1) % 6;
			days++;
			SetDawn ();
			break;
		}

		//The player's move between terrain action updates the state.
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
