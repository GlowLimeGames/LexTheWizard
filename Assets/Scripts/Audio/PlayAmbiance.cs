using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayAmbiance : MonoBehaviour {
    public static PlayAmbiance ambiences;

    string[] playAmbiance = { "Any", "PlayForestAmbiance", "PlayHillAmbiance", "PlaySwampAmbiance", "PlayCaveAmbiance" };
    private int currPlaying;
     private int gameController = GameController.gameController.currTerrainIndex;


    void Update()
    {
        gameController = GameController.gameController.currTerrainIndex;
        if (gameController != currPlaying)
        {
            print("NewAmbiance");
            currPlaying = gameController;
            EventController.Event(playAmbiance[currPlaying]);
        }
        else
        {
            
        }
    }
    // TODO add a call to this function in the game controller under the "moveterrain" function
    public void NewAmbiance()
    {
        gameController = GameController.gameController.currTerrainIndex;
        if (gameController != currPlaying)
        {
            print("NewAmbiance");
            currPlaying = gameController;
            EventController.Event(playAmbiance[currPlaying]);
        }
        else
        {

        }
    }
	
}
