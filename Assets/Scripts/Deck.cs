using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

    public List<CardInfo> cards;
    DeckShuffling deckShuffling;

    void Awake()
    {
        deckShuffling = GetComponent<DeckShuffling>();
        cards = new List<CardInfo>();
        MakeTestDeck();
    }

    void MakeTestDeck()
    {
        // Add cards
        cards.Add(new CardInfo("Title 1", "Swamp", 10, 20, "This is description 1 for Card 1.", "This is description 2 for Card 1."));
        cards.Add(new CardInfo("Title 2", "Swamp", 5, 15, "This is description 1 for Card 2.", "This is description 2 for Card 2."));
        cards.Add(new CardInfo("Title 3", "Swamp", 1, 2, "This is the description 1 for Card 3.", "This is the description 2 for Card 3."));
        cards.Add(new CardInfo("Title 4", "Swamp", 2, 3, "This is description 1 for Card 4.", "This is description 2 for Card 4."));
        cards.Add(new CardInfo("TItle 5", "Swamp", 6, 4, "This is the description 1 for Card 5.", "This is the description 2 for Card 5."));

        // Shuffle cards
        cards = deckShuffling.Shuffle(cards);

        Debug.Log("Number of cards in deck: " + cards.Count.ToString());
    }

    public CardInfo DrawCard()
    {
        if (cards.Count > 0)
        {
            return cards[0];
        }
        return null;
    }
}

public class CardInfo
{
    public string title;
    public string terrain;
    public string desc1;
    public string desc2;

    public int gold;
    public int salvage;

    public Sprite art;

    public CardInfo(string title, string terrain, int gold, int salvage, Sprite art, string desc1, string desc2)
    {
        this.title = title;
        this.terrain = terrain;
        this.desc1 = desc1;
        this.desc2 = desc2;
        this.gold = gold;
        this.salvage = salvage;
        this.art = art;
    }

    // For testing cards without art
    public CardInfo(string title, string terrain, int gold, int salvage, string desc1, string desc2)
    {
        this.title = title;
        this.terrain = terrain;
        this.desc1 = desc1;
        this.desc2 = desc2;
        this.gold = gold;
        this.salvage = salvage;
        this.art = null;
    }
}
