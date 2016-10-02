using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UpdateDayState : MonoBehaviour{

    public Text dayText;

    void Update()
    {
        
        if(GameController.INSTANCE == null)
        {
            Debug.Log("GameController Ins is null");
        }

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
