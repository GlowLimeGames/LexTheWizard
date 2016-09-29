using UnityEngine;
using System.Collections;
using System;

public class UpdateDayState : IGameState{

    public int dayCount = 0;

    public enum DayTime
    {
        Dawn,
        Dusk,
        Night
    }

    public DayTime currentDayTime = DayTime.Dawn;

    public void UpdateState()
    {

        currentDayTime++;
        if ((int)currentDayTime >= System.Enum.GetValues(typeof(DayTime)).Length)
        {
            currentDayTime = 0;
            dayCount++;

        }

        Debug.Log("Day " + dayCount + ": Time : " + currentDayTime + " Update the day cycle");
        GameFlowManager.INSTANCE.NextState();
    }

    void IGameState.Start()
    {
        
    }

}
