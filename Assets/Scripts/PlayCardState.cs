using UnityEngine;
using System.Collections;
using System;

public class PlayCardState : MonoBehaviour{

    void Update()
    {

    }

    public void NextButton()
    {
        
        GameController.INSTANCE.NextState();
    }
}
