using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
    public CardViewer cardShown;
    public CardViewer[] cards = new CardViewer[3];

    // Temporary field for testing
    private Card[] testCards = new Card[] {
        new Card("Card 1", "Random card #1", null),
        new Card("Card 2", "Random card #2", null),
        new Card("Card 3", "Random card #3", null)
    };

    void Start () {
        Draw();
    }

    // Temporary method for testing
    public void Draw () {
        foreach (CardViewer card in cards) {
            if (card.Card == null) {
                card.Card = testCards[Random.Range(0, testCards.Length)];
            }
        }
    }

    public void ShowCard(CardViewer card) {
        cardShown.Card = card.Card;
        cardShown.Index = card.Index;
        for (int i = 0; i < cards.Length; i++) {
            bool show = (i != card.Index && cards[i].Card != null);
            cards[i].Show(show);
        }
    }

    public void NextCard () {
        if (cardShown.Card == null)
        {
            return;
        }

        NextCard(cardShown.Index);
    }
    public void NextCard(int index) {
        SwitchCard(index, 1);
    }

    public void PreviousCard () {
        if (cardShown.Card == null)
        {
            return;
        }

        PreviousCard(cardShown.Index);
    }
    public void PreviousCard (int index) {
        SwitchCard(index, -1);
    }

    public void SwitchCard(int index, int dir, bool cardsLeft = false) {
        // First check to make sure there are still cards
        // in the hand.
        for (int i = 0; i < cards.Length && cardsLeft == false; i++) {
            if (cards[i].Card != null) { cardsLeft = true; }
        }

        // Only run this code if we've verified that there
        // is at least one card left.
        if (cardsLeft) {
            if ((dir == 1 && index < cards.Length - 1) || (dir == -1 && index > 0)) {
                index += dir;
            }
            else if (dir == 1) { index = 0; }
            else if (dir == -1) { index = cards.Length - 1; }

            if (cards[index].Card == null) { SwitchCard(index, dir, true); }
            else { ShowCard(cards[index]); }
        }
    }
    
    public void PlayCard() {
        if(cardShown.Card == null)
        {
            return;
        }

        print("Played the card, wow!");
        RemoveCard(cardShown);
    }
    
    public void SalvageCard() {
        if (cardShown.Card == null)
        {
            return;
        }

        print("Salvaged the card.");
        RemoveCard(cardShown);
    }

    private void RemoveCard(CardViewer card) {
        foreach (CardViewer c in cards) {
            if (c.Index == card.Index) {
                c.Card = null;
                if (cardShown.Index == card.Index)
                {
                    cardShown.Card = null;
                    cardShown.Index = -1;
                    NextCard(c.Index);
                }
                break;
            }
        }
    }
}