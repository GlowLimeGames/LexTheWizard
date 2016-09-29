using UnityEngine;
using System.Collections;
using System;

public class PlayCardState : IGameState{

    public void UpdateState()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("Player play the cards");
            GameFlowManager.INSTANCE.NextState();
        }

    }

    void IGameState.Start()
    {
        
    }

}
