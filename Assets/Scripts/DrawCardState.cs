using UnityEngine;
using System.Collections;
using System;

public class DrawCardState : MonoBehaviour{

    public Hand hand;

    public AudioClip drawCardSound;

    void Update()
    {

        Draw();

        SoundManager.instance.PlaySingle(drawCardSound);

        GameController.INSTANCE.NextState();
    }


    // Temporary field for testing
    public GameObject[] testCards;

    // Temporary method for testing
    public void Draw()
    {
        foreach (CardViewer card in hand.cards)
        {
            if (card.Card == null)
            {
                GameObject g = Instantiate(testCards[UnityEngine.Random.Range(0, testCards.Length)]);
                card.Card = g;
            }
        }
    }
}
