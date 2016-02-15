/*
 * Attached to Deck GameObject
 * Contains CardInfo as a nested class
 * 
 * Currently makes a test deck with 5 sample cards that are hard-coded
 * 
 * Has DrawCard function which is called from CardGame
 * 
 */

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

	// Temporary function
    void MakeTestDeck()
    {
        // Add sample cards
        cards.Add(new CardInfo("Title 1", "Swamp", 10, 20, "This is description 1 for Card 1.", "This is description 2 for Card 1."));
        cards.Add(new CardInfo("Title 2", "Swamp", 5, 15, "This is description 1 for Card 2.", "This is description 2 for Card 2."));
        cards.Add(new CardInfo("Title 3", "Swamp", 1, 2, "This is the description 1 for Card 3.", "This is the description 2 for Card 3."));
        cards.Add(new CardInfo("Title 4", "Swamp", 2, 3, "This is description 1 for Card 4.", "This is description 2 for Card 4."));
        cards.Add(new CardInfo("Title 5", "Swamp", 6, 4, "This is the description 1 for Card 5.", "This is the description 2 for Card 5."));

        // Shuffle cards
        cards = deckShuffling.Shuffle(cards);
    }

	// This function is called from CardGame
    public CardInfo DrawCard()
    {
		// If there are cards left in the deck
        if (cards.Count > 0)
        {
			// Read the card from the top of the deck
			CardInfo nextCard = cards[0];
			// Remove the card from deck
			cards.Remove(cards[0]);
			return nextCard;
        }
        return null;
    }
}

// Doesn't inherit from MonoBehavior so we can call "new" in Deck class
// This means CardInfo is not actually attached to an object
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
