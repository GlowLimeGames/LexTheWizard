/*
 * Attached to Discard Pile GameObject 
 * 
 */
using UnityEngine;
/*
 * Attached to Discard Icon
 * 
 * Only applies to Player Card Objects
 */
using System.Collections;
using System.Collections.Generic;

public class DiscardPile : MonoBehaviour {

    //public string discardType;

    UIManager UImanager;
    GameController gameController;
    Player player;
    CardObject selectedCard;

    void Start() {
        UImanager = UIManager.UImanager;
        gameController = GameController.gameController;
        player = Player.player;
    }

    void OnMouseDown() {
        if (selectedCard != null) {
            UImanager.ShowConfirmMenu(true);
            Discard();
        }
    }

    public void Discard()
    {
        selectedCard = player.SelectedCard;
        CardGame.Instance.SetPositionFree(selectedCard.GetHandPosition()); // Set hand position as free
        player.RemoveCardFromHand(selectedCard);
        selectedCard.gameObject.SetActive(false);
		selectedCard = null;

        UImanager.ShowActionIcons(false);
        gameController.MoveTerrain();
    }

    /*void OnCollisionEnter2D(Collision2D coll)
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
    }*/

}
