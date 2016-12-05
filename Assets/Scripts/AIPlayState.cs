using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AIPlayState : MonoBehaviour{
    public CardViewer shownCard;
    public GameObject AIcard;
    public AudioClip aiPlayCardSound;
    private float timer = 2f;

    void OnEnable() {
        Fungus.Flowchart.BroadcastFungusMessage("AIPlayStateStart");
    }

    void Update() {
        if (timer == 2f) {
            //Play the AI card
            shownCard.Card = CardDatabase.DrawAI();
            SoundManager.instance.PlaySingle(aiPlayCardSound);
        }
        else if(timer < 0) {
            //Wait 2 seconds before moving to the next state
            timer = 2f;
            if (shownCard.Card != null) { shownCard.Card.OnPlay(); }
            shownCard.Card = null;
            GameController.INSTANCE.NextState();

            return;
        }

        timer -= Time.deltaTime;
    }
}