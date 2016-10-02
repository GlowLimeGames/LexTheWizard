﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UpdateTerrainState : MonoBehaviour{

    public Text terrainText;

    void Update()
    {
        int r = UnityEngine.Random.Range(1, 5);

        switch (r)
        {
            case 1:
                GameController.INSTANCE.currentTerrain = GameController.Terrain.Forrests;
                break;
            case 2:
                GameController.INSTANCE.currentTerrain = GameController.Terrain.Caves;
                break;
            case 3:
                GameController.INSTANCE.currentTerrain = GameController.Terrain.Swamps;
                break;
            case 4:
                GameController.INSTANCE.currentTerrain = GameController.Terrain.Hills;
                break;
            default:
                break;
        }

        terrainText.text = GameController.INSTANCE.currentTerrain.ToString();

        GameController.INSTANCE.NextState();
    }
}