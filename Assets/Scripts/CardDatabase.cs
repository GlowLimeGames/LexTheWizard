using UnityEngine;
using System.Collections.Generic;

public class CardDatabase {
    private static List<Card> AICardPool = new List<Card>();
    private static List<Card> PlayerCardPool = new List<Card>();
    private static List<Card> PlayerDeck = new List<Card>();
    private static List<Card> AIDeck = new List<Card>();

    public static void AddCard (LexCard lexCard, bool ai) {
        Card card = new Card(lexCard);
        List<Card> deck = ai ? AICardPool : PlayerCardPool;

        card.Type = ai ? Card.CardType.AI : Card.CardType.Player;
        deck.Add(card);
    }

    private static Card Draw(List<Card> deck, bool onlyPlayable = false) {
        int index;
        Card card = null;
        if (deck.Count == 0) {
            Debug.Log("Out of cards!");
        }
        else if (onlyPlayable) {
            List<Card> subDeck = new List<Card>();
            foreach (Card c in deck) {
                if (c.isCurrentlyPlayable()) {
                    subDeck.Add(c);
                }
            }
            card = Draw(subDeck, false);
        }
        else {
            index = Random.Range(0, deck.Count);
            card = deck[index];
            deck.Remove(card);
            // Debug.Log("Drew " + card.Name);
        }
        return card;
    }

    public static Card DrawPlayer() { return Draw(PlayerDeck); }
    public static Card DrawAI() { return Draw(AIDeck, true); }

    private static void UpdateDeck(List<Card> deck, List<Card> cardPool) {
        List<Card> remove = new List<Card>();
        foreach (Card card in cardPool) {
            if (card.isInPlay()) {
                deck.Add(card);
                remove.Add(card);
            }
        }
        foreach (Card card in remove) {
            cardPool.Remove(card);
        }
    }

    public static void UpdateDecks() {
        UpdateDeck(AIDeck, AICardPool);
        UpdateDeck(PlayerDeck, PlayerCardPool);
    }
}