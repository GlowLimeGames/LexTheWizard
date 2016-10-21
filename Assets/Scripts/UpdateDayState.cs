using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UpdateDayState : MonoBehaviour{

    [SerializeField]
    private Text dayText;

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

        dayText.text = "Day " + GameController.INSTANCE.dayCount + ": " + GameController.INSTANCE.currentDayTime.ToString();
        GameController.INSTANCE.NextState();
    }

}
