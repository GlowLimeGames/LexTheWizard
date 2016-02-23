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
	public DeckType DeckType;

    public List<CardInfo> cards;
    DeckShuffling deckShuffling;

    void Awake()
    {
        deckShuffling = GetComponent<DeckShuffling>();
        cards = new List<CardInfo>();
        MakeTestDeck();
    }

	void addStaticCardsToDeck () {
        // Add sample cards
		cards.Add(new CardInfo("Title 1", "Swamp", "Night", "Discovery", 2, 10, 20, 1, "This is description 1 for Card 1.", "This is description 2 for Card 1.",0));
		cards.Add(new CardInfo("Title 2", "Swamp", "Dawn", "Event", 1, 5, 15, 2, "This is description 1 for Card 2.", "This is description 2 for Card 2.",0));
		cards.Add(new CardInfo("Title 3", "Swamp", "Dusk", "Event", 3, 1, 2, 1, "This is the description 1 for Card 3.", "This is the description 2 for Card 3.",0));
		cards.Add(new CardInfo("Title 4", "Swamp", "Morning", "Discovery", 1, 2, 3, 1, "This is description 1 for Card 4.", "This is description 2 for Card 4.",0));
		cards.Add(new CardInfo("Title 5", "Swamp", "Afternoon", "Discovery", 4, 6, 4, 3, "This is the description 1 for Card 5.", "This is the description 2 for Card 5.",0));
	}

	// Temporary function
    void MakeTestDeck()
    {
		
		if (DeckType == DeckType.Player) {
		
			cards = new List<CardInfo>(CardUtil.PlayerDeck);

		} else if (DeckType == DeckType.AI) {

			cards = new List<CardInfo>(CardUtil.AIDeck);

		}

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
	public DeckType deckType;

    public string title;
    public string terrain;
	public string daytime;
	public string cardType;
    public string desc1;
    public string desc2;

    public int points;
    public int gold;
    public int salvage;
    public int homeValue;
	public int aiValue;

    public Sprite art;

	public CardInfo(string title, string terrain, string daytime, string cardType, int points, int gold, int salvage, int homeValue, Sprite art, string desc1, string desc2)
    {
        this.title = title;
        this.terrain = terrain;
		this.daytime = daytime;
        this.cardType = cardType;
        this.desc1 = desc1;
        this.desc2 = desc2;
        this.points = points;
        this.gold = gold;
        this.salvage = salvage;
        this.homeValue = homeValue;
        this.art = art;
		deckType = DeckType.Player;
    }

    // For testing cards without art
	public CardInfo(string title, string terrain, string daytime, string cardType, int points, int gold, int salvage, int homeValue, string desc1, string desc2, int aiValue)
    {
        this.title = title;
        this.terrain = terrain;
		this.daytime = daytime;
        this.cardType = cardType;
        this.desc1 = desc1;
        this.desc2 = desc2;
        this.points = points;
        this.gold = gold;
        this.salvage = salvage;
        this.homeValue = homeValue;
        this.art = null;
		this.aiValue = aiValue;
    }


	public CardInfo (string title, string terrain, string cardType, string description, string effect, int aiValue) {
		this.deckType = DeckType.AI;

		this.title = title;
		this.terrain = terrain;
		this.cardType = cardType;
		this.desc1 = description;
		this.desc2 = effect;
		this.aiValue = aiValue;
	}

	public override string ToString ()
	{
		if (deckType == DeckType.Player) {
			
			return string.Format (
				"[Player CardInfo], Title: {0}, Terrain: {1}, Time of Day: {2}, Card Type: {3}," +
				" Points: {4}, Salvage: {5}, Home Value: {6}, Sprite: {7}, Description 1: {8}, Description 2: {9}",
				title,
				terrain,
				daytime,
				cardType,
				points,
				gold,
				salvage,
				homeValue,
				art.name,
				desc1,
				desc2
			);

		} else if (deckType == DeckType.AI) {

			return string.Format (
				"[AI CardInfo], Title: {0}, Type {1}, Terrain: {2}, Description: {3}, Effect: {4}, AI Value: {5}",
				title,
				cardType,
				terrain,
				desc1,
				desc2,
				aiValue
			);

		} else {

			return base.ToString();

		}

	}
}