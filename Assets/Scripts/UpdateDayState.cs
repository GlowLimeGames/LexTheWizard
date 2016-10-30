using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UpdateDayState : MonoBehaviour{

    [SerializeField]
    private Image dayIcon;

    [SerializeField]
    private Text dayCount;

    public Sprite daySprite;
    public Sprite afternoonSprite;
    public Sprite nightSprite;


    void OnEnable()
    {
        Fungus.Flowchart.BroadcastFungusMessage("UpdateDayStateStart");
    }

    void Update()
    {

        GameController.INSTANCE.currentDayTime++;
        if ((int)GameController.INSTANCE.currentDayTime >= System.Enum.GetValues(typeof(GameController.DayTime)).Length)
        {
            GameController.INSTANCE.currentDayTime = 0;
            GameController.INSTANCE.dayCount++;

        }

        switch (GameController.INSTANCE.currentDayTime)
        {
            case GameController.DayTime.Dawn:
                dayIcon.sprite = daySprite;
                break;
            case GameController.DayTime.Dusk:
                dayIcon.sprite = afternoonSprite;
                break;
            case GameController.DayTime.Night:
                dayIcon.sprite = nightSprite;
                break;
            default:
                break;
        }

        dayCount.text = "" + GameController.INSTANCE.dayCount;
        GameController.INSTANCE.NextState();
    }

}
