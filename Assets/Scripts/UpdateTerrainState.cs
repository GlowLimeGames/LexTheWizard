using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UpdateTerrainState : MonoBehaviour{

    void OnEnable()
    {
        Fungus.Flowchart.BroadcastFungusMessage("UpdateTerrainStateStart");
    }

    void Update() {
        RandomTerrain();
        GameController.INSTANCE.NextState();
    }

    public static void RandomTerrain() {
        GameController.Terrain terrain = (GameController.Terrain)UnityEngine.Random.Range(0, 4);
        MoveToTerrain(terrain);
    }

    public static void MoveToTerrain(GameController.Terrain terrain) {
        GameController.INSTANCE.currentTerrain = terrain;
    }
}
