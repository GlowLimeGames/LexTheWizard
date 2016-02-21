/*
 * Attached to Discard Pile GameObject 
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiscardPile : MonoBehaviour {

    CardObject selectedCard;

    void Discard(CardObject cardObject)
    {
        Destroy(cardObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject colObject = coll.gameObject;
        if (colObject.tag == "Card")
        {
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
