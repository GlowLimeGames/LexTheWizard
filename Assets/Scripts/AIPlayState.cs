using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AIPlayState : MonoBehaviour{

    public Hand hand;

    public CardViewer AIcard;

    private float timer = 2f;

    void Update()
    {
        Debug.Log("AI played a card");

        hand.ShowCard(AIcard);

        if(timer < 0)
        {
            timer = 2f;
            GameController.INSTANCE.NextState();
        }

        timer -= Time.deltaTime;
    }

}
