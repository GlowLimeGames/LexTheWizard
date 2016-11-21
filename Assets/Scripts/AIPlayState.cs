using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AIPlayState : MonoBehaviour{

    public CardViewer shownCard;

    public GameObject AIcard;

    private float timer = 2f;

    public AudioClip aiPlayCardSound;

    void OnEnable()
    {
        Fungus.Flowchart.BroadcastFungusMessage("AIPlayStateStart");
    }

    void Update()
    {
        //TODO: Have AI play card from deck

        if (timer == 2f)
        {
            //Play the AI card
            shownCard.Card = Instantiate(CardDatabase.DrawAI());
            SoundManager.instance.PlaySingle(aiPlayCardSound);
        }
        else if(timer < 0)
        {
            //Wait 2 seconds before moving to the next state
            timer = 2f;
            shownCard.Card = null;
            GameController.INSTANCE.NextState();

            return;
        }

        timer -= Time.deltaTime;
        

    }

}
