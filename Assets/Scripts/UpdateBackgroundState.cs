using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateBackgroundState : MonoBehaviour {
    public static UpdateBackgroundState INSTANCE;
    public Image background;

    public Sprite[] terrainType;

    void Awake() {
        if (INSTANCE == null) {
            INSTANCE = this;
        }
    }

    void OnEnable()
    {
        Fungus.Flowchart.BroadcastFungusMessage("UpdateBackgroundStateStart");
    }

    // Update is called once per frame
    void Update () {
        UpdateBackground();
        GameController.INSTANCE.NextState();
	}

    public void UpdateBackground ()
    {
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
    }
}
