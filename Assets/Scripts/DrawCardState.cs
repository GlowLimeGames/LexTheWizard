using UnityEngine;
using System.Collections;
using System;

public class DrawCardState : MonoBehaviour{
    public Hand hand;
    public AudioClip drawCardSound;

    void Update() {
        hand.Draw();
        SoundManager.instance.PlaySingle(drawCardSound);
        GameController.INSTANCE.NextState();
    }
}
