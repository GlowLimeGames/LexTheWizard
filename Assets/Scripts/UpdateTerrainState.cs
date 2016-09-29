using UnityEngine;
using System.Collections;
using System;

public class UpdateTerrainState : IGameState{

    public enum Terrain
    {
        Swamps,
        Hills,
        Forrests,
        Caves
    }

    public Terrain currentTerrain = Terrain.Swamps;

    public void UpdateState()
    {
        Debug.Log("Change Terrain if the conditions are met");
        GameFlowManager.INSTANCE.NextState();
    }

    void IGameState.Start()
    {
        
    }

}
