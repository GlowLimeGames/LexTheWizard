/*
 * Attached to GameManager object 
 * 
 * Contains function for dealing cards
 * Instantiates Card Prefabs with CardObject components
 * Draws cards from Deck
 * 
 * Will eventually handle end of turns, signal opponent to play a card, etc.
 */
using UnityEngine;
using System.Collections;

public class CardGame : MonoBehaviour {

    public Deck deck; // Reference to Deck from deck GameObject
    public Transform[] handTargets; // Array for transforms for each card in the user's hand
    public GameObject cardTemplate; // Reference to card prefab
    public GameObject cardCanvas; // Reference to canvas containing cards

    int numOfStartingCards;
    Vector3 cardScale;

    Tuning tuning; // Reference to tuning object

	void Start () {
        tuning = Tuning.tuning;
        numOfStartingCards = tuning.numOfStartingCards;

        cardScale = new Vector3(0.25f, 0.25f);
        DealCards(numOfStartingCards);
	}

    // This is called when the card game starts
	// Deals the number of starting cards to the player
    void DealCards(int numOfCards)
    {
        for (int i = 0; i < numOfCards; i++)
        {
            Transform currentTransform = handTargets[i];

            // Instantiate prefab with the current transform
            GameObject cardPrefab = (GameObject) Instantiate(cardTemplate, currentTransform.position, currentTransform.rotation);
            // Sets scale
			cardPrefab.transform.localScale = cardScale;
			// Makes cardPrefab the child of the cardCanvas
			cardPrefab.transform.parent = cardCanvas.transform;
			// Attaches a CardObject component
            CardObject cardObject = cardPrefab.AddComponent<CardObject>();

            // Get cardInfo from next item in the deck
            CardInfo cardInfo = deck.DrawCard();
            // Assign the CardInfo to this CardObject
            cardObject.CreateCard(cardInfo);
        }
    }
}
