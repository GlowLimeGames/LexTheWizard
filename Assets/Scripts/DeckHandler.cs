using UnityEngine;
using System.Collections.Generic;

public class DeckHandler {
    private static List<Card> AICardPool = new List<Card>();
    private static List<Card> PlayerCardPool = new List<Card>();
    private static List<Card> PlayerDeck = new List<Card>();
    private static List<Card> AIDeck = new List<Card>();

    private static Card Draw(List<Card> deck, bool onlyPlayable = false) {
        int index;
        Card card;
        if (onlyPlayable) {
            List<Card> subDeck = new List<Card>();
            foreach (Card c in deck) {
                if (c.isCurrentlyPlayable()) {
                    subDeck.Add(c);
                }
            }
            index = Random.Range(0, subDeck.Count);
            card = subDeck[index];
        }
        else {
            index = Random.Range(0, deck.Count);
            card = deck[index];
        }
        deck.Remove(card);
        return card;
    }

    public static Card DrawPlayer() { return Draw(PlayerDeck); }
    public static Card DrawAI() { return Draw(AIDeck, true); }

    private static void UpdateDeck(List<Card> deck, List<Card> cardPool) {
        foreach (Card card in cardPool) {
            if (card.isInPlay()) {
                deck.Add(card);
                cardPool.Remove(card);
            }
        }
    }

    public static void UpdateDecks() {
        UpdateDeck(AIDeck, AICardPool);
        UpdateDeck(PlayerDeck, PlayerCardPool);
    }
}