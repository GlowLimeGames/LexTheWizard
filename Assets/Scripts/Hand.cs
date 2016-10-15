﻿using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
    //public CardViewer cardShown;
    public CardViewer[] cards = new CardViewer[3];

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
                if(value >= 0)
                {
                    cards[currentCardIndex].Show(true);
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


        print("Played the card, wow!");
        RemoveCard(CurrentCardIndex);
        
    }
    
    public void SalvageCard() {
        
        if(CurrentCardIndex == -1)
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
}