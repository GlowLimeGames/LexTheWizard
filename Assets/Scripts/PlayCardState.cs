using UnityEngine;
using System.Collections;
using System;

public class PlayCardState : MonoBehaviour{

    Vector3 startTouchPos;
    public Hand hand;
    float distsq = 4000f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 d = Input.mousePosition - startTouchPos;
            if (d.sqrMagnitude > distsq)
            {
                if(Math.Abs(d.x) > Math.Abs(d.y))
                {
                    //Horizontal swipe
                    if(d.x < 0)
                    {
                        hand.PreviousCard();
                    }
                    else
                    {
                        hand.NextCard();
                    }
                }
                else
                {
                    //Vertical swipe
                    if (d.y < 0)
                    {
                        hand.SalvageCard();
                    }
                    else
                    {
                        hand.PlayCard();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            hand.PlayCard();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            hand.SalvageCard();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            hand.PreviousCard();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            hand.NextCard();
        }
    }

    public void NextButton()
    {
        
        GameController.INSTANCE.NextState();
    }
}
