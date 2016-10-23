using UnityEngine;
using System.Collections.Generic;

public class DeckHandler {
    private static List<LexCard> AICardPool = new List<LexCard>();
    private static List<LexCard> PlayerCardPool = new List<LexCard>();
    private static List<LexCard> PlayerDeck = new List<LexCard>();
    private static List<LexCard> AIDeck = new List<LexCard>();

    private static LexCard[] Draw(int amt, List<LexCard> deck, bool onlyPlayable = false) {
        int index;
        LexCard[] cards = new LexCard[amt];
        if (onlyPlayable) {
            List<LexCard> subDeck = new List<LexCard>();
            foreach (LexCard c in deck) {
                if (c.isCurrentlyPlayable()) {
                    subDeck.Add(c);
                }
            }
            for (int i = 0; i < cards.Length; i++) {
                index = Random.Range(0, subDeck.Count);
                cards[i] = subDeck[index];
                deck.Remove(cards[i]);
            }
        }
        else {
            for (int i = 0; i < cards.Length; i++) {
                index = Random.Range(0, deck.Count);
                cards[i] = deck[index];
                deck.Remove(cards[i]);
            }
        }
        return cards;
    }

    public static LexCard DrawPlayer() { return DrawPlayer(1)[0]; }
    public static LexCard[] DrawPlayer(int amt) { return Draw(amt, PlayerDeck); }
    public static LexCard DrawAI() { return DrawAI(1)[0]; }
    public static LexCard[] DrawAI(int amt) { return Draw(amt, AIDeck, true); }

    private static void UpdateDeck(List<LexCard> deck, List<LexCard> cardPool) {
        foreach (LexCard card in cardPool) {
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