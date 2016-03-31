using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : CardPlayer {
	
	public static Player player; // Static instance of this class
    DiscardPile discard;
	
	// Stat variables
	int points;
	
	// Card Player variables
	CardObject selectedCard; // Player Card Object
    CardObject viewedCard; // Enemy Card Object the player is viewing
	
	void Awake() {
		player = this;
		base.Awake ();
	}
	
	void Start() {
		base.Start ();
		cardPlayerName = "Lex";
	}
	
	// This allows other objects to get stats from Player without reassigning them
	public int[] GetStats()
	{
		return new int[1] {points};
	}
	
	public void ChangeStats(int pointsChange)
	{
		points += pointsChange;
		UImanager.SetStats(points);
	}
	
	public override void PlayCard(CardObject cardObject) {
		selectedCard = cardObject;
		UImanager.ShowConfirmMenu(true);
	}

    public void PlayCard()
    {
        UImanager.ShowConfirmMenu(true);
    }

    public void Discard()
    {
        if (discard == null)
        {
            discard = UImanager.Discard;
        }
        discard.Discard();
    }
	
	public void Confirm(bool isConfirmed) {
        if (isConfirmed)
        {
            CardInfo playedCardInfo = selectedCard.GetCardInfo();
            string cardName = playedCardInfo.title;
            RemoveCardFromHand(selectedCard);

            int pointsChange = playedCardInfo.points;

            if (pointsChange > 0)
            {
                EventController.Event("PointIncrease");
            }

            ChangeStats(pointsChange);
            CardGame.Instance.SetPositionFree(selectedCard.GetHandPosition()); // Set hand position as free
            selectedCard.PlayEffect();
            gameController.Turn();

            Debug.Log("Lex just played " + cardName + ".");
            selectedCard = null;
        }
        else
        {
            Debug.Log("Lex cancelled");
        }		
	}

    // Returns currently selected card to hand
    public void ReturnCardToHand()
    {
        selectedCard.Shrink();
        selectedCard = null;
    }

    public void ReturnViewedCard()
    {
        Debug.Log("trying to return viewed card");
        viewedCard.Shrink();
        viewedCard = null;
    }

    public CardObject SelectedCard
    {
        get { return selectedCard; }
        set { selectedCard = value; }
    }

    public CardObject ViewedCard
    {
        get { return viewedCard; }
        set { viewedCard = value; }
    }
}