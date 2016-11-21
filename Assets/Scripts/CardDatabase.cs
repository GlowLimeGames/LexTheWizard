using UnityEngine;
using System.Collections.Generic;

public class CardDatabase {
    private static List<Card> AICardPool = new List<Card>();
    private static List<Card> PlayerCardPool = new List<Card>();
    private static List<Card> PlayerDeck = new List<Card>();
    private static List<Card> AIDeck = new List<Card>();

    public static void AddCard (Card card) {
        List<Card> deck = (card.Type == LexCard.Type.AI) ? AICardPool : PlayerCardPool;
        if (deck.Contains(card)) { Debug.Log("Re-added " + card.Name); }
        deck.Add(card);
    }

    private static Card Draw(List<Card> deck, bool onlyPlayable, List<Card> subset = null) {
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
            card = Draw(deck, false, subDeck);
        }
        else {
            if (subset == null) { subset = deck; }
            card = subset[Random.Range(0, subset.Count)];
            deck.Remove(card);
        }
        return card;
    }

    public static Card DrawPlayer() { return Draw(PlayerDeck, false); }
    public static Card DrawAI() { return Draw(AIDeck, true); }

    private static void UpdateDeck(List<Card> deck, List<Card> cardPool) {
        List<Card> remove = new List<Card>();
        foreach (Card card in cardPool) {
            if (card.isInPlay()) {
                if (deck.Contains(card)) { Debug.Log("Re-added " + card.Name); }
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