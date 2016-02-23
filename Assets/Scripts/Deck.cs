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
        cards.Add(new CardInfo("Title 1", "Hills", "Night", "Discovery", 2, 10, 20, 1, "This is description for Card 1.",0));
        cards.Add(new CardInfo("Title 2", "Hills", "Dawn", "Event", 1, 5, 15, 2, "This is description for Card 2.",0));
        cards.Add(new CardInfo("Title 3", "Forest", "Dusk", "Event", 3, 1, 2, 1, "This is the description for Card 3.",0));
        cards.Add(new CardInfo("Title 4", "Forest", "Morning", "Discovery", 1, 2, 3, 1, "This is description for Card 4.",0));
        cards.Add(new CardInfo("Title 5", "Hills", "Afternoon", "Discovery", 4, 6, 4, 3, "This is the description for Card 5.",0));

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
	public string daytime;
	public string cardType;
    public string desc;

    public int points;
    public int gold;
    public int salvage;
    public int homeValue;
	public int aiValue;

    public Sprite art;

	public CardInfo(string title, string terrain, string daytime, string cardType, int points, int gold, int salvage, int homeValue, Sprite art, string desc)
    {
        this.title = title;
        this.terrain = terrain;
		this.daytime = daytime;
        this.cardType = cardType;
        this.desc = desc;
        this.points = points;
        this.gold = gold;
        this.salvage = salvage;
        this.homeValue = homeValue;
        this.art = art;
    }

    // For testing cards without art
	public CardInfo(string title, string terrain, string daytime, string cardType, int points, int gold, int salvage, int homeValue, string desc, int aiValue)
    {
        this.title = title;
        this.terrain = terrain;
		this.daytime = daytime;
        this.cardType = cardType;
        this.desc = desc;
        this.points = points;
        this.gold = gold;
        this.salvage = salvage;
        this.homeValue = homeValue;
        this.art = null;
		this.aiValue = aiValue;
    }
}
