using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AIPlayState : MonoBehaviour{

    public Text eventText;
    private float timeLeft = 2f;

    void Update()
    {
        eventText.text = "AI played a card";
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 2f;
            GameController.INSTANCE.NextState();
        }
    }

}
