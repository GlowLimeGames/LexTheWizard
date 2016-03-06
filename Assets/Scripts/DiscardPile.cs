/*
 * Attached to Discard Pile GameObject 
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiscardPile : MonoBehaviour {

    public string discardType;

    CardObject selectedCard;

    void Discard(CardObject cardObject)
    {
        if (discardType == "Sell")
        {




            int goldChange = cardObject.GetCardInfo().gold;

			if (goldChange > 0) {
				EventController.Event("GoldIncrease");
			}

			//Debug.Log (goldChange);
            Player.player.ChangeStats(0, goldChange, 0);
        }
        else if (discardType == "Salvage")
        {



            int salvageChange = cardObject.GetCardInfo().salvage;

			if (salvageChange > 0) {
				EventController.Event("SalvageIncrease");
			}

			//Debug.Log (salvageChange);
            Player.player.ChangeStats(0, 0, salvageChange);
        }
		cardObject.GetOwner ().RemoveCardFromHand (cardObject);
        cardObject.gameObject.SetActive(false);
		selectedCard = null;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject colObject = coll.gameObject;
        if (colObject.tag == "Card") {
			selectedCard = colObject.GetComponent<CardObject>();
		}
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (selectedCard != null)
            {
                Discard(selectedCard);
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        GameObject colObject = coll.gameObject;
        if (colObject.tag == "Card")
        {
            selectedCard = null;
        }
    }
}
