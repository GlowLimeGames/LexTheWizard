using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
    public const int HAND_SIZE = 3;

    public CardViewer[] cards = new CardViewer[HAND_SIZE];
    public CardViewer shownCard;

    private int currentCardIndex = -1;
    public int CurrentCardIndex {
        get
        {
            return currentCardIndex;
        }
        set
        {
            if(value >= cards.Length)
            {
                Debug.LogError("Cannot set card index to " + value + " there is only " + cards.Length + " card slots");
            }
            else if(value == -1 || cards[value].Card != null)
            {
                currentCardIndex = value;
                shownCard.Card = null;
                if(value != -1)
                {
                    shownCard.Card = cards[currentCardIndex].Card;
                }
            }
            else
            {
                Debug.LogError("Cannot set card index to " + value + " because that card does not exist");
            }
        }
    }

    public AudioClip discardCardSound;

    public void ShowCard(int index) {
        CurrentCardIndex = index;
    }

    public void NextCard () {
        if (CurrentCardIndex == -1)
        {
            return;
        }

        int newIndex = 1;
        while (cards[(CurrentCardIndex + newIndex) % cards.Length].Card == null)
        {
            newIndex++;
            if(newIndex == cards.Length)
            {
                return;
            }
        }

        CurrentCardIndex = (CurrentCardIndex + newIndex) % cards.Length;
    }

    public void PreviousCard () {
        if (CurrentCardIndex == -1)
        {
            return;
        }

        int newIndex = 1;
        while (cards[(CurrentCardIndex - newIndex + cards.Length) % cards.Length].Card == null)
        {
            newIndex++;
            if (newIndex == cards.Length)
            {
                return;
            }
        }

        CurrentCardIndex = (CurrentCardIndex - newIndex + cards.Length) % cards.Length;
    }
    
    public void PlayCard() {
        
        if(CurrentCardIndex == -1)
        {
            return;
        }

        cards[CurrentCardIndex].Card.OnPlay();

        RemoveCard(CurrentCardIndex);
        
    }
    
    public void SalvageCard() {
        
        if(CurrentCardIndex == -1 || GameController.INSTANCE.currentDayTime == GameController.DayTime.Night)
        {
            return;
        }

        SoundManager.instance.PlaySingle(discardCardSound);

        GameController.INSTANCE.Mana++;
        RemoveCard(CurrentCardIndex);

    }

    private void RemoveCard(int index) {
        
        cards[index].Card = null;

        NextCard();
        if(index == CurrentCardIndex)
        {
            CurrentCardIndex = -1;
        }
    }

    public int Draw(int numberOfCards = HAND_SIZE) {
        int cardsDrawn = 0;
        for (int j = 0; j < cards.Length && cardsDrawn < numberOfCards; j++) {
            if (cards[j].Card == null) {
                cards[j].Card = CardDatabase.DrawPlayer();
                cardsDrawn++;
            }
        }
        return cardsDrawn;
    }

    public int Discard(int numberOfCards = HAND_SIZE) {
        int cardsDiscarded = 0;
        for (int j = 0; j < cards.Length && cardsDiscarded < numberOfCards; j++) {
            if (cards[j].Card != null) {
                cards[j].Card = null;
                cardsDiscarded++;
            }
        }
        return cardsDiscarded;
    }
}