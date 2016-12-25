using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hand : MonoBehaviour {
    public const int HAND_SIZE = 3;

    public static Hand INSTANCE;

    public CardViewer[] cards = new CardViewer[HAND_SIZE];
    public CardViewer shownCard;

    public GameObject infoPanel;

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

    void Awake() {
        if (INSTANCE == null) {
            INSTANCE = this;
        }
    }

    public void ShowCard(int index) {
        CurrentCardIndex = index;
        infoPanel.SetActive(false);
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
        if (CurrentCardIndex != -1) {
            if (cards[CurrentCardIndex].Card.isCurrentlyPlayable()) {
                cards[CurrentCardIndex].Card.OnPlay();
                RemoveCard(CurrentCardIndex);
            }
            else {
                Debug.Log("Card not playable in this terrain or day phase");
            }
        }
    }
    
    public void SalvageCard() {
        if(CurrentCardIndex != -1) {
            SalvageCard(CurrentCardIndex);
        }
    }

    public void SalvageCard(int index) {
        if (GameController.INSTANCE.currentDayTime != GameController.DayTime.Night) {
            SoundManager.instance.PlaySingle(discardCardSound);
            GameController.INSTANCE.Mana++;
            RemoveCard(CurrentCardIndex);
        }
    }

    private void RemoveCard(int index) {
        cards[index].Card = null;

        if(index == CurrentCardIndex) {
            NextCard();
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

    public int Discard(int numberOfCards = HAND_SIZE, bool mana = true) {
        int cardsDiscarded = 0;
        for (int j = 0; j < cards.Length && cardsDiscarded < numberOfCards; j++) {
            if (cards[j].Card != null) {
                if (mana) { SalvageCard(j); }
                else { RemoveCard(j); }
                cardsDiscarded++;
            }
        }
        return cardsDiscarded;
    }

    public int CountCards() {
        int count = 0;
        foreach (CardViewer c in cards) {
            if (c.Card != null) { count++; }
        }
        return count;
    }
}