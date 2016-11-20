using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateBackgroundState : MonoBehaviour {

    public Image background;

    public Sprite[] terrainType;

    void OnEnable()
    {
        Fungus.Flowchart.BroadcastFungusMessage("UpdateBackgroundStateStart");
    }

    // Update is called once per frame
    void Update () {

        switch (GameController.INSTANCE.currentTerrain)
        {
            case GameController.Terrain.Caves:
                background.sprite = terrainType[0];
                break;
            case GameController.Terrain.Forests:
                background.sprite = terrainType[1];
                break;
            case GameController.Terrain.Hills:
                background.sprite = terrainType[2];
                break;
            case GameController.Terrain.Swamps:
                background.sprite = terrainType[3];
                break;
            default:
                break;
        }

        GameController.INSTANCE.NextState();
	}
}
