using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayAmbiance : MonoBehaviour {

    string[] playAmbiance = { "Any", "PlayForestAmbiance", "PlayHillAmbiance", "PlaySwampAmbiance", "PlayCaveAmbiance" };
    private int currPlaying;
     private int gameController = GameController.gameController.currTerrainIndex;


    void Update()
    {
        gameController = GameController.gameController.currTerrainIndex;
        if (gameController != currPlaying)
        {
            currPlaying = gameController;
            EventController.Event(playAmbiance[currPlaying]);
        }
        else
        {
            
        }
    }
	
}
