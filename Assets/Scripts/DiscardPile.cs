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
            Player.player.ChangeStats(0, goldChange, 0);
        }
        else if (discardType == "Salvage")
        {
            int salvageChange = cardObject.GetCardInfo().salvage;
            Player.player.ChangeStats(0, 0, salvageChange);
        }
        cardObject.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject colObject = coll.gameObject;
        if (colObject.tag == "Card")
        {
            selectedCard = colObject.GetComponent<CardObject>();
        }
    }

    /*void OnCollisionStay2D(Collision2D coll)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (selectedCard != null)
            {
                Discard(selectedCard);
            }
        }
    }*/

    void OnCollisionExit2D(Collision2D coll)
    {
        GameObject colObject = coll.gameObject;
        if (colObject.tag == "Card")
        {
            selectedCard = null;
        }
    }

    /*void OnMouseEnter()
    {
        Debug.Log("mouse has entered");
        Debug.Log(discardType);
        if (selectedCard != null)
        {
            selectedCard.Shrink();
        }
    }*/

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (selectedCard != null)
            {
                Discard(selectedCard);
            }
        }
    }

    /*void OnMouseExit()
    {
        Debug.Log("mouse has exited");
        if (selectedCard != null)
        {
            selectedCard.Grow();
        }
    }
     */
}
