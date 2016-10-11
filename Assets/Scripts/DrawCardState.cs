using UnityEngine;
using System.Collections;
using System;

public class DrawCardState : MonoBehaviour{

    public Hand hand;

    void Update()
    {

        hand.Draw();
        GameController.INSTANCE.NextState();
    }

}
