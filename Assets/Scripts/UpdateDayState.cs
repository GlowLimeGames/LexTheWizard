using UnityEngine;
using System.Collections;
using System;

public class UpdateDayState : IGameState{

    public void UpdateState()
    {
        Debug.Log("Day " + GameFlowManager.INSTANCE.dayCount + ": " + "Update the day cycle");
        GameFlowManager.INSTANCE.NextState();
    }

    void IGameState.Start()
    {
        
    }

}
