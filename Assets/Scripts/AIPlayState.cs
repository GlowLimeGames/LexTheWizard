using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AIPlayState : MonoBehaviour{

    public Hand hand;

    public CardViewer AIcard;

    private float timer = 2f;

    public AudioClip aiPlayCardSound;

    void Update()
    {
        //TODO: Have AI play card from deck
        
        //hand.ShowCard(AIcard);

        if(timer < 0)
        {
            timer = 2f;
            SoundManager.instance.PlaySingle(aiPlayCardSound);
            GameController.INSTANCE.NextState();
        }

        timer -= Time.deltaTime;
        

    }

}
