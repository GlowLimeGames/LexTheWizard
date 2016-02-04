using UnityEngine;
using System.Collections;

public class DeckShuffling : MonoBehaviour {

	public int [] initialDeck;
	public int [] shuffledDeck;
	public int randomNum;

	
	// Use this for initialization
	void Start () {
		initialDeck = new int[52];
		shuffledDeck = new int[52];
		
		//puts the number 1 to 52 in each spot in the array and 0 in the shuffled deck
		for (int i = 0; i <= 51; i++) {
			initialDeck [i] = i + 1;
			shuffledDeck [i] = 0;
		}
		//loop to place all the numbers in the initial deck into a random spot in the shuffled deck
		for (int j = 0; j <= 51; j++) {
			bool cardPlaced = false;
			//generated a random number between 0 and 51, checks if the value in the shuffled deck is 0, places the number from initial deck in the random index
			//continues generating random number until an empty spot is found
			while (cardPlaced == false) {
				randomNum = Random.Range (0,52);
				if(shuffledDeck[randomNum] == 0)
				{
					shuffledDeck[randomNum] = initialDeck[j];
					cardPlaced = true;
				}
			}
		}
		for (int k = 0; k<=51; k++) {
			print (shuffledDeck[k]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
