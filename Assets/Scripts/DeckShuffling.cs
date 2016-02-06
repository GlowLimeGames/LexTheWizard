using UnityEngine;
using System.Collections;

public class DeckShuffling : MonoBehaviour {
	
	public Card [] initialDeck;
	public Card[] shuffledDeck;
	public int randomNum;

	void Start () {
		initialDeck = new Card[52];
		shuffledDeck = new Card[52];
		
		//puts the number 1 to 52 in the card number for each card in the array and 0 in the shuffled deck card number
		for (int i = 0; i <= 51; i++) {
			initialDeck[i] = new Card();
			shuffledDeck[i] = new Card();
			initialDeck [i].cardNumber = i + 1;
			shuffledDeck [i].cardNumber = 0;
		}
		//loop to place all the numbers in the initial deck into a random spot in the shuffled deck
		for (int j = 0; j <= 51; j++) {
			bool cardPlaced = false;
			//continues generating random number until an empty spot is found
			while (cardPlaced == false) {
                //generated a random number between 0 and 51
				randomNum = Random.Range (0,52);
                //checks if the value in the shuffled deck is 0
				if(shuffledDeck[randomNum].cardNumber == 0)
				{
                    //places the number from initial deck in the random index
					shuffledDeck[randomNum].cardNumber = initialDeck[j].cardNumber;
					cardPlaced = true;
				}
			}
		}
		for (int k = 0; k<=51; k++) {
			print (shuffledDeck[k].cardNumber);
		}
	}
}
