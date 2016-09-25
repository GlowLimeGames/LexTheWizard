using UnityEngine;
using System.Collections;
using System;

public class DrawCardState : IGameState{

    public void UpdateState()
    {
        Debug.Log("Day " + GameFlowManager.INSTANCE.dayCount + ": " + "Draw the cards");
        GameFlowManager.INSTANCE.NextState();
    }

    void IGameState.Start()
    {
        
    }

}
