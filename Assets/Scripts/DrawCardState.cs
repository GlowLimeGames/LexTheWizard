using UnityEngine;
using System.Collections;
using System;

public class DrawCardState : MonoBehaviour{

    // Temporary field for testing
    private Card[] testCards = new Card[] {
        new Card("Card 1", "Random card #1", null),
        new Card("Card 2", "Random card #2", null),
        new Card("Card 3", "Random card #3", null)
    };

    void Update()
    {
        GameController.INSTANCE.Card1 = testCards[UnityEngine.Random.Range(0, testCards.Length)];
        GameController.INSTANCE.Card2 = testCards[UnityEngine.Random.Range(0, testCards.Length)];
        GameController.INSTANCE.Card3 = testCards[UnityEngine.Random.Range(0, testCards.Length)];

        GameController.INSTANCE.NextState();
    }

}
