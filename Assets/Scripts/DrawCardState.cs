using UnityEngine;
using System.Collections;
using System;

public class DrawCardState : IGameState{

    public void UpdateState()
    {
        Debug.Log("Draw the cards");
        GameFlowManager.INSTANCE.NextState();
    }

    void IGameState.Start()
    {
        
    }

}
