using UnityEngine;
using System.Collections;
using System;

public class PlayCardState : MonoBehaviour{

    Vector3 startTouchPos;
    public Hand hand;

    void Update()
    {
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
