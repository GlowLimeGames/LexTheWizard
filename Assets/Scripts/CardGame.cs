using UnityEngine;
using System.Collections;

public class CardGame : MonoBehaviour {

    public Deck deck;
    public Transform[] handTargets;
    public GameObject cardTemplate;
    public GameObject cardCanvas;

    int numOfStartingCards;
    Vector3 cardScale;
    Tuning tuning;

	void Start () {
        tuning = Tuning.tuning;
        numOfStartingCards = tuning.numOfStartingCards;
        cardScale = new Vector3(0.625f, 0.5769231f);
        DealCards(numOfStartingCards);
	}

    // This is called when the card game starts
    void DealCards(int numOfCards)
    {
        Debug.Log("About to deal cards");
        for (int i = 0; i < numOfCards; i++)
        {
            Transform currentTransform = handTargets[i];

            // Instantiate prefab with the current transform
            GameObject cardPrefab = (GameObject) Instantiate(cardTemplate, currentTransform.position, currentTransform.rotation);
            cardPrefab.transform.localScale = cardScale;
            CardObject cardObject = cardPrefab.AddComponent<CardObject>();

            // Get cardInfo from next item in the deck
            CardInfo cardInfo = deck.DrawCard();

            // Assign the cardInfo to this card
            cardObject.CreateCard(cardInfo);

            Debug.Log("Card should have been created");
        }
    }
}
