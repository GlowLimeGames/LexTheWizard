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

	// Enum determines whether this is a player of an AI deck
	public DeckType DeckType;

    public List<CardInfo> cards;
    DeckShuffling deckShuffling;
    GameController gameController;

    void Start()
    {
        gameController = GameController.gameController;
        deckShuffling = GetComponent<DeckShuffling>();
        cards = new List<CardInfo>();
        MakeTestDeck();
    }

	void addStaticCardsToDeck () {
        // Add sample cards
		Sprite placeholder = Resources.Load<Sprite>("Cards/Placeholder");
		cards.Add(new CardInfo("Title 1", new Land[1] {gameController.GetTerrainByName("Swamp")}, "Night", "Discovery", 2, 10, 20, 1, placeholder, "This is description 1 for Card 1."));
		cards.Add(new CardInfo("Title 2", new Land[1] {gameController.GetTerrainByName("Swamp")}, "Dawn", "Event", 1, 5, 15, 2, placeholder, "This is description 1 for Card 2."));
        cards.Add(new CardInfo("Title 3", new Land[1] { gameController.GetTerrainByName("Swamp") }, "Dusk", "Event", 3, 1, 2, 1, placeholder, "This is the description 1 for Card 3."));
        cards.Add(new CardInfo("Title 4", new Land[1] { gameController.GetTerrainByName("Swamp") }, "Morning", "Discovery", 1, 2, 3, 1, placeholder, "This is description 1 for Card 4."));
        cards.Add(new CardInfo("Title 5", new Land[1] { gameController.GetTerrainByName("Swamp") }, "Afternoon", "Discovery", 4, 6, 4, 3, placeholder, "This is the description 1 for Card 5."));
	}

	// Temporary function
    void MakeTestDeck()
    {

		// Generates the appropriate type of deck
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
    public Land[] terrains;
	public string daytime;
	public string cardType;
    public string desc;

    public int points;
    public int gold;
    public int salvage;
    public int homeValue;
	public int aiValue;

    public Sprite art;

	// Constructor for a player card
	public CardInfo(string title, Land[] terrains, string daytime, string cardType, int points, int gold, int salvage, int homeValue, Sprite art, string desc)
    {
        this.title = title;
        this.terrains = terrains;
		this.daytime = daytime;
        this.cardType = cardType;
        this.desc = desc;
        this.points = points;
        this.gold = gold;
        this.salvage = salvage;
        this.homeValue = homeValue;
        this.art = art;
		deckType = DeckType.Player;
    }

    // For testing cards without art
	public CardInfo(string title, Land[] terrains, string daytime, string cardType, int points, int gold, int salvage, int homeValue, string desc, int aiValue)
    {
        this.title = title;
        this.terrains = terrains;
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

	// Constructor for an AI Card
	public CardInfo (string title, Land[] terrains, string cardType, string description, int aiValue) {
		this.deckType = DeckType.AI;

		this.title = title;
		this.terrains = terrains;
		this.cardType = cardType;
		this.desc = description;
		this.aiValue = aiValue;
	}

	public override string ToString ()
	{
		if (deckType == DeckType.Player) {
			
			return string.Format (
				"[Player CardInfo], Title: {0}, Terrains: {1}, Time of Day: {2}, Card Type: {3}," +
				" Points: {4}, Salvage: {5}, Home Value: {6}, Sprite: {7}, Description: {8}",
				title,
				terrains,
				daytime,
				cardType,
				points,
				gold,
				salvage,
				homeValue,
				art.name,
				desc
			);

		} else if (deckType == DeckType.AI) {

			return string.Format (
				"[AI CardInfo], Title: {0}, Type {1}, Terrains: {2}, Description: {3}, AI Value: {4}",
				title,
				cardType,
				terrains,
				desc,
				aiValue
			);

		} else {

			return base.ToString();

		}

	}
}