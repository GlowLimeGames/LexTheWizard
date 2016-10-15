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

        if(timer == 2f)
        {
            //Play the AI card
            SoundManager.instance.PlaySingle(aiPlayCardSound);
        }
        else if(timer < 0)
        {
            //Wait 2 seconds before moving to the next state
            timer = 2f;
            GameController.INSTANCE.NextState();
        }

        timer -= Time.deltaTime;
        

    }

}
