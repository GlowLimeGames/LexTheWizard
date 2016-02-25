/*
 * Attached to all characters that participate in the card game.
 * 
 * Contains functions for getting cards list and adding/removing cards from the character's hand.
 * 
 * This script is referenced in CardGame.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardPlayer : MonoBehaviour {

    string cardPlayerName; // Name of character

    List<CardObject> cards = new List<CardObject>(); // Reference to cards in hand

    public void PlayCard(CardObject cardObject)
    {
		CardInfo playedCardInfo = cardObject.GetCardInfo();
        // Temporary, don't want to hard code this
        if (cardPlayerName == "Lex")
        {
			int pointsChange = playedCardInfo.points;

			if (pointsChange > 0) {
				EventController.Event("PointIncrease");
			}

            Player.player.ChangeStats(pointsChange, 0, 0);
			GameController.gameController.Turn ();
        }
        string cardName = cardObject.GetCardInfo().title;
        Debug.Log(cardName + " has been played by " + cardPlayerName);
        RemoveCardFromHand(cardObject);
		string message = "";
		if (cardPlayerName == "Enemy") {
			message += "                     --------->\n";
		}
		message += cardPlayerName + " just played " + cardName + ".\nIt has _____ effect.";
		if (cardPlayerName == "Enemy") {
			message += "\nTap to read more about it!";
		}
		UIManager.UImanager.showPopup(message);
	}

    public List<CardObject> GetCards()
    {
        return cards;
    }


    public void AddCardToHand(CardObject cardObject)
    {
        cards.Add(cardObject);
    }

    public void RemoveCardFromHand(CardObject cardObject)
    {
        cards.Remove(cardObject);
        Debug.Log("Cards left in " + cardPlayerName + "\'s hand: " + cards.Count.ToString());
    }

    public void SetName(string name)
    {
        cardPlayerName = name;
    }

	public int NumberOfCardsOnHand () {
		return cards.Count;
	}
}
