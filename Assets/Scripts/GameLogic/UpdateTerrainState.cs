using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class UpdateTerrainState : MonoBehaviour{

    void OnEnable()
    {
        Fungus.Flowchart.BroadcastFungusMessage("UpdateTerrainStateStart");
    }

    void Update() {
        if (GameController.INSTANCE.currentDayTime == GameController.DayTime.Dawn) {
            RandomTerrain();
        }
        GameController.INSTANCE.NextState();
    }

    public static void RandomTerrain() {
        List<GameController.Terrain> newTerrains = new List<GameController.Terrain>();
        foreach (GameController.Terrain t in Enum.GetValues(typeof(GameController.Terrain))) {
            if (GameController.INSTANCE.currentTerrain != t) {
                newTerrains.Add(t);
            }
        }
        GameController.Terrain terrain = newTerrains[UnityEngine.Random.Range(0, newTerrains.Count)];
        MoveToTerrain(terrain);
    }

    public static void MoveToTerrain(GameController.Terrain terrain) {
        GameController.INSTANCE.currentTerrain = terrain;
    }
}
