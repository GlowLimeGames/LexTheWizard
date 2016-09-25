using UnityEngine;
using System.Collections;
using System;

public class UpdateTerrainState : IGameState{

    public void UpdateState()
    {
        Debug.Log("Day " + GameFlowManager.INSTANCE.dayCount + ": " + "Change Terrain if the conditions are met");
        GameFlowManager.INSTANCE.NextState();
    }

    void IGameState.Start()
    {
        
    }

}
