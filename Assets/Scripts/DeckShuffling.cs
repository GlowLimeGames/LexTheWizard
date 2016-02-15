/* 
 * Attached to Deck GameObject
 * Contains function to shuffle the deck
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckShuffling : MonoBehaviour {

	// This function is called from Deck when a new deck is made
	public List<CardInfo> Shuffle (List<CardInfo> initialDeck) {
		// Get the number of cards from the initial deck
        int numOfCards = initialDeck.Count;
		// Create an empty array
        CardInfo[] shuffledDeck = new CardInfo[numOfCards];
		
        // Fill cards in array with null
		for (int i = 0; i <= numOfCards - 1; i++) {
			shuffledDeck [i] = null;
		}

		// Loop to place all the numbers in the initial deck into a random spot in the shuffled deck
        int randomNum;
		for (int j = 0; j <= numOfCards - 1; j++) {
			bool cardPlaced = false;
			// Continue generating random number until an empty spot is found
			while (cardPlaced == false) {
                // Generate a random index within the array
                randomNum = Random.Range(0, numOfCards);
                // Check if the value in the shuffled deck is empty
				if(shuffledDeck[randomNum] == null)
				{
					// If so,
                    // Places the card from initial deck in the random index
					shuffledDeck[randomNum] = initialDeck[j];
					cardPlaced = true;
				}
			}
		}

        // Convert array to list
        List<CardInfo> newDeck = new List<CardInfo>();
        for (int k = 0; k <= numOfCards - 1; k++)
        {
            newDeck.Add(shuffledDeck[k]);
        }

		// Return the new shuffled deck
        return newDeck;
	}
}
