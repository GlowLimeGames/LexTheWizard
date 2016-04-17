using UnityEngine;
using System.Collections;

[System.Serializable]
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

	private EnemyBehavior enemy;
	private Player player;

	private gameState currState;
	//TODO track in save
	private gameState[] previousTerrain = new gameState[6];
	private int terrainIndex;
	private int phase;

    private GameObject[] cardTemplates; 
	private GameObject cardCanvas;

	// variables to track family members status
	public bool isFatherAlive;
	public bool isSisterAlive;
	public bool isGrandmaAlive;

	public SaveData saveData;

	UIManager UImanager;
	Tuning tuning;

	int winPoints;

	void Awake() {
		gameController = this;
	}

	void Start () {

		EventController.Event("PlayGameMusic");
		UImanager = UIManager.UImanager;
		UImanager.SetupUI ();

		tuning = Tuning.tuning;

		days = 0;
		SetDawn ();

		terrainIndex = 1;

		winPoints = tuning.winPoints;

		//tuning.winPoints = 40;

		isFatherAlive = true;
		isSisterAlive = true;
		isGrandmaAlive = true;

		cardGame = GetComponent<CardGame>();
		enemy = cardGame.enemy;
		player = cardGame.player;
		playerDeck = player.GetDeck();
		enemyDeck = enemy.GetDeck ();
		cardGame.SetupCardGame (playerDeck, enemyDeck);

		cardTemplates = new GameObject[2] {cardGame.playerCardTemplate, cardGame.enemyCardTemplate};
		cardCanvas = cardGame.cardCanvas;

        //Initializes array of traversable terrain as the only current terrain       
		currTerrainIndex = 1;
        currTerrain = terrains [currTerrainIndex];
		currState = new gameState();
		currState.setTerrain (currTerrain);
		phase = 0;
		previousTerrain [0] = currState;        
        for (int i = 1; i < previousTerrain.Length; i++) {
			previousTerrain [i] = null;
		}

		cardGame.BeginCardGame ();
	}

	/*
	 * Called from UIManager when:
	 * - PauseButton is pressed
	 * - ReturnToGame Button is pressed
	 * 
	 * Pauses when input is true
	 * Unpauses when input is false 
	 */
	public void Pause(bool pauseGame) {
		if (pauseGame) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	/*
	 * Turn mechanics
	 */
	public void Turn() {
		//TODO write playCard() to play the card in question

		switch(phase){
		//1st Draw (Player and AI both draw)
		case 0:		
			// make player discard a card if hand is full
			// TODO change this so player can choose between discarding new card or some old card
			if (player.NumberOfCardsInHand () == tuning.handLimit) {
				UImanager.ShowPopup ("Hand full! Discard at least one card to draw another one.");
			}
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
			UImanager.ShowGameOver (isGameOver ());
			if (!Win ()) {
				cardGame.showEnemyCard ();
			}
			phase = (phase + 1) % 6;
			SetAfternoon ();
			break;

		//Afternoon/Action 2
		case 2:			
			UImanager.ShowGameOver (isGameOver ());
			if (!Win ()) {
				cardGame.showEnemyCard ();
			}
			phase = (phase + 1) % 6;
			SetDusk ();
			break;

		//Dusk/Action 3
		case 3:			
			UImanager.ShowGameOver (isGameOver ());
			if (!Win ()) {
				cardGame.showEnemyCard ();
			}
			phase = (phase + 1) % 6;
			SetNight ();
			break;

		//2nd draw phase
		case 4:			
			// make player discard a card if hand is full
			// TODO change this so player can choose between discarding new card or some old card
			if (player.NumberOfCardsInHand () == tuning.handLimit) {
				UImanager.ShowPopup ("Hand full! Discard at least one card to draw another one.");
			}
			//Deals Cards to the player
			cardGame.DealCards (1, playerDeck, cardGame.playerHandTargets, player);
			//Deals Cards to the AI
			cardGame.DealCards (1, enemyDeck, cardGame.enemyHandTargets, enemy);
			phase = (phase + 1) % 6;
			Turn ();
			break;

		//Night/Action 4
		case 5:			
			UImanager.ShowGameOver (isGameOver ());
			if (!Win ()) {
				cardGame.showEnemyCard ();
			}
			//This time phase will loop back to 0
			phase = (phase + 1) % 6;
			SetDawn ();
			break;
		}
		// chech win condition after every phase
		UImanager.ShowWinPopup (Win());
		//Autosave after every phase.
		SaveGame ();
	}

	public int getCurrPhase(){
		return phase;
	}

	/*
	 * Phases of day mechanics
	 */
	public void SetDawn() {
		currDayTime = "Dawn";
		days++;
	}
	public void SetAfternoon() {
		currDayTime = "Afternoon";
	}
	public void SetDusk() {
		currDayTime = "Dusk";
	}
	public void SetNight() {
		currDayTime = "Night";
	}

	/*
	* Win mechanics
	*/

	// raise winning condition for points
	public void raisePoints (int amount) {
		winPoints += amount;
	}

	private bool isGameOver(){
		return player.NumberOfCardsInHand () == 0;
	}

	public bool Win() {
		int[] stats = player.GetStats ();
		if (stats [0] >= winPoints) {
			return true;
		} else {
			return false;
		}
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
	/*
	* Terrain mechanics
	*/
	public void MoveTerrain() {
		//Random select terrain
		int nextTerr = Random.Range(1,terrains.Length);
		//Prevents the same terrain being chosen
		if (nextTerr == currTerrainIndex) {
			nextTerr = (nextTerr+1)%terrains.Length;
		}
		//Tracking previous terrains
		previousTerrain[terrainIndex] = currState;
		phase = (phase + 1) % 6;
		currState = new gameState ();
		currState.setTerrain (nextTerr);
	}

	public void MoveTo(string terr) {
		//Tracking previous terrains
		int nextTerr = -1;
		if(terr == "hills"){
			nextTerr = 2;
		}else if(terr == "cave"){
			nextTerr = 4;
		}else if(terr == "swamp"){
			nextTerr = 3;
		}else{
			nextTerr = 1;
		}
		previousTerrain[terrainIndex] = currState;
		currState = new gameState ();
		currState.setTerrain (nextTerr);
	}

	public static void SaveGame () {
		//When save is called, the save data instance in this class updates its variabes and serializes using SaveSystem's save function

		//By necessity, save Decks and Hands by the titles of their cards
		foreach(CardObject card in gameController.player.GetHand ()){
			gameController.saveData.playerHand.Add (card.GetCardInfo().title);
		}
		foreach(CardInfo card in gameController.player.GetDeck().cards){
			gameController.saveData.playerDeck.Add (card.title);
		}
		foreach(CardObject card in CardGame.Instance.enemy.GetHand ()){
			gameController.saveData.enemyHand.Add (card.GetCardInfo().title);
		}
		foreach(CardInfo card in CardGame.Instance.enemy.GetDeck ().cards){
			gameController.saveData.enemyDeck.Add (card.title);
		}


		gameController.saveData.score = gameController.player.points;
		gameController.	saveData.phase = gameController.phase;
		gameController.saveData.days = gameController.days;
		gameController.saveData.currDayTime = gameController.currDayTime;
		gameController.	saveData.currTerrain = gameController.currTerrain.name;
		gameController.saveData.currTerrainIndex = gameController.currTerrainIndex;

		SaveSystem.Save ();
	}

	public static void LoadData (){
		SaveSystem.Load ();
		gameController.saveData = SaveSystem.saveGame;

		//TODO write method to get card info from csv based only on title

	/*	//gameController.player.GetHand (). = gameController.saveData.playerHand;
		foreach(string card in gameController.saveData.playerHand){
			Deck loadPlayerHand = new Deck //with all cards 
			player.
				gameController.saveData.playerHand.Count
			//Deals Cards to the player
			//cardGame.DealCards (1, toLoadHand, cardGame.playerHandTargets, player);
			//Deals Cards to the AI
			//cardGame.DealCards (1, enemyDeck, cardGame.enemyHandTargets, enemy);
		}*/
		//gameController.player.GetDeck ().cards = gameController.saveData.playerDeck;
		//gameController.saveData.enemyHand = CardGame.Instance.enemy.GetHand ();
		//CardGame.Instance.enemy.GetDeck ().cards = gameController.saveData.enemyDeck;

		gameController.player.points = gameController.saveData.score;
		gameController.phase = gameController.saveData.phase; 
		gameController.days = gameController.saveData.days;
		gameController.currDayTime = gameController.saveData.currDayTime;
		gameController.currTerrain = gameController.GetTerrainByName(gameController.saveData.currTerrain);
		gameController.currTerrainIndex = gameController.saveData.currTerrainIndex;
	}


	public CardGame thisCardGame {
		get { return cardGame; }
	}

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
