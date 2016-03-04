/*
 * Attached to PlayerCardObjects
 * Handles Mouse and Collision Events (beyond that of the CardObject parent class)
 * 
 * Script for click and drag: http://answers.unity3d.com/questions/12322/drag-gameobject-with-mouse.html
 * 
 */
using UnityEngine;
using System.Collections;

public class ClickAndDrag : MonoBehaviour {

    CardObject cardObject;
    bool locked;
    bool inHand;
    bool played;

    Camera mainCam;
    Vector3 screenPoint;
    Vector3 offset;
    
    void Start()
    {
        mainCam = Camera.main;
        cardObject = GetComponent<CardObject>();
    }

    void OnMouseDown()
    {
        // Assign screenPoint and offset in case user will drag the mouse
        screenPoint = mainCam.WorldToScreenPoint(gameObject.transform.position);
        //mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        offset = gameObject.transform.position - mainCam.ScreenToWorldPoint(GetMousePosition());
    }

    void OnMouseUp()
    {
        if (!inHand && !cardObject.Played)
        { // If card hasn't been played yet and is on the board
            cardObject.PlayCard();
            locked = true;
        }
    }


    void OnMouseDrag()
    {
        if (!locked)
        {
            transform.position = mainCam.ScreenToWorldPoint(GetMousePosition()) + offset;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!locked)
        {
            string colTag = coll.gameObject.tag;
            switch (colTag)
            {
                case "Hand":
                    inHand = true;
                    break;
                /* // Discard Collisions handled in CardCenter
                 * case "Discard":
                    Shrink();
                    break;*/
            }
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (!locked)
        {
            string colTag = coll.gameObject.tag;
            switch (colTag)
            {
                case "Hand":
                    inHand = true;
                    break;
                /* // Discard Collisions handled in CardCenter
                case "Discard":
                    if (!hasShrunk)
                    {
                        //Shrink();
                    }
                    break;*/
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (!locked)
        {
            string colTag = coll.gameObject.tag;
            switch (colTag)
            {
                case "Hand":
                    inHand = false;
                    break;
                /* // Discard Collisions handled in CardCenter
                case "Discard":
                    //Grow();
                    break;*/
            }
        }
    }

    Vector3 GetMousePosition()
    {
        return new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    }


    public void Lock()
    {
        locked = true;
        /*CardCenter cardCenter = GetComponentInChildren<CardCenter> ();
        Destroy (cardCenter.gameObject.GetComponent<BoxCollider2D> ());
        Destroy (cardCenter);
        Debug.Log ("destroying cardCenter");*/
    }
}
