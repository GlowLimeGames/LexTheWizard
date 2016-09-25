using UnityEngine;
using System.Collections;
using System;

public class AIPlayState : IGameState{

    public void UpdateState()
    {
        Debug.Log("AI playes the cards");
        GameFlowManager.INSTANCE.NextState();
    }

    void IGameState.Start()
    {
        
    }

}
