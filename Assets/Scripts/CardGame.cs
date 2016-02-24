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
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CardGame : MonoBehaviour {
	public static CardGame Instance;

    public CardPlayer player;
    public CardPlayer enemy;

    public Deck playerDeck; // Reference to Deck from Player Deck GameObject
    public Deck enemyDeck; // Reference to Deck from Enemy Deck GameObject

    public Transform[] playerHandTargets; // Array of transforms for each card in the player's hand
    public Transform[] enemyHandTargets; // Array of transforms for each card in enemy's hand

    public Transform[] enemyBoardTargets; // Where the enemy will place cards on the board

    public GameObject cardTemplate; // Reference to card prefab
    //public Sprite cardTemplateSprite;
    public GameObject cardCanvas; // Reference to canvas containing cards

    List<CardObject> playerCards; // Reference to cards from Player's CardPlayer
    List<CardObject> enemyCards; // Reference to cards from Enemy's CardPlayer

    Tuning tuning; // Reference to tuning object
    int numOfStartingCards;
    Vector3 cardScale;

	void Start () {
		Instance = this;

        tuning = Tuning.tuning;
        numOfStartingCards = tuning.numOfStartingCards;
        cardScale = tuning.cardScale;

        playerCards = player.GetCards();
        enemyCards = enemy.GetCards();

        DealCards(numOfStartingCards, playerDeck, playerHandTargets, player);
        DealCards(numOfStartingCards, enemyDeck, enemyHandTargets, enemy);

        showEnemyCard();
	}

    // This is called when the card game starts
	// Deals the number of starting cards to the player
    void DealCards(int numOfCards, Deck deck, Transform[] handTargets, CardPlayer cardPlayer)
    {
        for (int i = 0; i < numOfCards; i++)
        {
            Transform currentTransform = handTargets[i];

            // Instantiate prefab with the current transform
            GameObject cardPrefab = (GameObject) Instantiate(cardTemplate, currentTransform.position, currentTransform.rotation);
            // Sets scale
			cardPrefab.transform.localScale = cardScale;
			// Makes cardPrefab the child of the cardCanvas
			cardPrefab.transform.SetParent(cardCanvas.transform, false);
            //cardPrefab.GetComponent<SpriteRenderer>().sprite = cardTemplateSprite;
			// Attaches a CardObject component
            CardObject cardObject = cardPrefab.AddComponent<CardObject>();
            // Get cardInfo from next item in the deck
            CardInfo cardInfo = deck.DrawCard();
            // Assign the CardInfo to this CardObject
            cardObject.CreateCard(cardInfo);
			//cardObject.SetBackgroundImage(cardTemplateSprite);
            // Give the CardObject reference to its CardPlayer
			cardObject.SetOwner(cardPlayer);
            // Add the CardObject to CardPlayer's hand
            cardPlayer.AddCardToHand(cardObject);
        }
    }

    // Temporary function
    // Makes enemy play first card and displays it on the board
    void showEnemyCard()
    {
        CardObject card = enemyCards[0];
        card.transform.position = enemyBoardTargets[0].position;
        enemy.PlayCard(card);
    }
}
