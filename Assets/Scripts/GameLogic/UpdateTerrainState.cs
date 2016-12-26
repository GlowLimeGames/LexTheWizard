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
        if (GameController.instance.currentDayTime == GameController.DayTime.Morning) {
            RandomTerrain();
        }
        GameController.instance.NextState();
    }

    public static void RandomTerrain() {
        List<GameController.Terrain> newTerrains = new List<GameController.Terrain>();
        foreach (GameController.Terrain t in Enum.GetValues(typeof(GameController.Terrain))) {
            if (GameController.instance.currentTerrain != t) {
                newTerrains.Add(t);
            }
        }
        GameController.Terrain terrain = newTerrains[UnityEngine.Random.Range(0, newTerrains.Count)];
        MoveToTerrain(terrain);
    }

    public static void MoveToTerrain(GameController.Terrain terrain) {
        GameController.instance.currentTerrain = terrain;
    }
}
