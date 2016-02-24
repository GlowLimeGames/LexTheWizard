﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController gameController;

	// variable to track days passed
	public int days;
	// variable to track current time of the day
	public string currDayTime;
	// variable to track all available terrains
	public Land[] terrains;
	// variable to track current terrain
	public Land currTerrain;
	public int currTerrainIndex;

	private CardGame cardGame;
	private Deck playerDeck;
	private Deck enemyDeck;

	private CardPlayer enemy;
	private CardPlayer player;

	private gameState currState;
	private gameState[] previousTerrain = new gameState[6];
	private int phase;


	private GameObject cardTemplate;
	private GameObject cardCanvas;

	// variables to track family members status
	public bool isFatherAlive;
	public bool isSisterAlive;
	public bool isGrandmaAlive;

	//TODO associate with unwritten move home. For alpha win if points is good.
	// win conditions varibles
	int winPoints;
	int winGold;
	int winSalvage;

	void Awake() {
		gameController = this;
	}

	void Start () {
		days = 0;
		SetDawn ();

		//currTerrain

		winPoints = 30;
		winGold = 25;
		winSalvage = 40;

		isFatherAlive = true;
		isSisterAlive = true;
		isGrandmaAlive = true;

		cardGame = GetComponent<CardGame>();
		enemy = cardGame.enemy;
		player = cardGame.player;
		playerDeck = cardGame.playerDeck;
		enemyDeck = cardGame.enemyDeck;

		cardTemplate = cardGame.cardTemplate;
		cardCanvas = cardGame.cardCanvas;



		//Initializes array of traversable terrain as the only current terrain
		currTerrainIndex = 0;
		currTerrain = terrains [currTerrainIndex];
        currState = new gameState();
		currState.setTerrain (currTerrain);
		phase = 0;
		previousTerrain [0] = currState;
		for (int i = 1; i < previousTerrain.Length; i++) {
			previousTerrain [i] = null;
		}
	}

	/*
	 * Turn mechanics
	 */
	public void Turn() {
		//TODO write playCard() to play the card in question

		//Temp var to reduce the number of calls and create cards
		CardObject usedCard = null;

		switch(phase){
		//1st Draw (Player and AI both draw)
		case 0:		
			//here usedCard is just a CardObject to facilitate drawing
			//Deals Cards to the player
			cardGame.DealCards (1, playerDeck, cardGame.playerHandTargets, player);
			//Deals Cards to the AI
			cardGame.DealCards (1, enemyDeck, cardGame.enemyHandTargets, enemy);
			//Cycles 0 to 5 to represent the phases.
			phase = (phase + 1) % 6;
			Turn ();
			break;

		//Dawn/Action 1
		case 1:			
			//TODO Update art to Dawn
			usedCard = enemy.GetComponent<EnemyBehavior>().selectCard ();
			if (usedCard != null) {
				enemy.PlayCard(usedCard);
			}

			phase = (phase + 1) % 6;
			SetAfternoon ();
			break;

		//Afternoon/Action 2
		case 2:			
			//Update art to Afternoon
			usedCard = enemy.GetComponent<EnemyBehavior>().selectCard();
			if (usedCard != null) {
				enemy.PlayCard(usedCard);
			}
			phase = (phase + 1) % 6;
			SetDusk ();
			break;
		//Dusk/Action 3
		case 3:			
			//Update art to Dusk
			usedCard = enemy.GetComponent<EnemyBehavior>().selectCard ();
			if (usedCard != null) {
				enemy.PlayCard(usedCard);
			}
			phase = (phase + 1) % 6;
			SetNight ();
			break;

		//2nd draw phase
		case 4:			
			//Deals Cards to the player
			cardGame.DealCards (1, playerDeck, cardGame.playerHandTargets, player);
			//Deals Cards to the AI
			cardGame.DealCards (1, enemyDeck, cardGame.enemyHandTargets, enemy);
			phase = (phase + 1) % 6;
			Turn ();
			break;

		//Night/Action 4
		case 5:			
			//Update art to Night
			//Check if current state has shelter when enemy plays cards at night
			usedCard = enemy.GetComponent<EnemyBehavior>().selectCard ();
			if (usedCard != null) {
				enemy.PlayCard(usedCard);
			}
			//This time phase will loop back to 0
			phase = (phase + 1) % 6;
			SetDawn ();
			break;
		}
	}

	/*
	 * Phases of day mechanics
	 */

	// sets time to dawn and updates days passed
	public void SetDawn() {
		currDayTime = "Dawn";
		days++;
	}

	// sets time to afternoon
	public void SetAfternoon() {
		currDayTime = "Afternoon";
	}

	// sets time to dusk
	public void SetDusk() {
		currDayTime = "Dusk";
	}

	// sets time to night
	public void SetNight() {
		currDayTime = "Night";
	}

	/*// the possible phases of the day
	public enum DayTime {
		Dawn,
		Afternoon,
		Dusk,
		Night
	};*/

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

	public Land GetTerrainByName(string name) {
		for (int i = 0; i < terrains.Length; i++) {
			Land terrain = terrains[i];
			if (terrain.name == name) {
				return terrain;
			}
		}
		return GetTerrainByName ("Any");
	}

	public void MoveTerrain() {
		if (currTerrainIndex < terrains.Length - 1) {
			//currTerrainIndex++;
			currState.setTerrain (Random.Range(0,4));
		}
	}

	//NOTE: May move below and associated code to more appropriate class.
	//Tracks the previous terrain type and whether Lex used a shelter there.
	//This is stored in an array in the parent class for Lex to access.
	private class gameState {
		private Land terrainType;
		private bool shelter;
		GameController gameController;

		void Start() {
			gameController = GameController.gameController;
		}

		public bool getShelter(){
			return shelter;
		}

		public string getTerrainName(){
			return terrainType.name;
		}

		public void setTerrain(Land terrain){
			this.terrainType = terrain;
			UIManager.UImanager.SetBoard (terrainType);
		}

		public void setTerrain(int terrainIndex) {
			this.terrainType = GameController.gameController.terrains [terrainIndex];
			UIManager.UImanager.SetBoard (terrainType);
		}

		public void setShelter(bool shelterUsed){
			this.shelter = shelterUsed;
		}
	}
}
