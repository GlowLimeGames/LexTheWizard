using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

    List<Card> cards;
    DeckShuffling deckShuffling;

    void Awake()
    {
        deckShuffling = GetComponent<DeckShuffling>();
    }

	void Start () {
        //MakeTestDeck();
	}

    void MakeTestDeck()
    {
        cards.Add(new Card("Title 1", "Swamp", 10, 20, "Description 1", "Description 2"));
        cards.Add(new Card("Title 2", "Swamp", 5, 15, "Description 1", "Description 2"));
    }

	
}
