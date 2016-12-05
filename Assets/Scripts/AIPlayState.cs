using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AIPlayState : MonoBehaviour{
    public CardViewer shownCard;
    public GameObject AIcard;
    public AudioClip aiPlayCardSound;
    public RectTransform r;
    private bool isStartedTouchPanel = false;
    Vector3 startTouchPos;


    void OnEnable() {
        Fungus.Flowchart.BroadcastFungusMessage("AIPlayStateStart");
        shownCard.Card = CardDatabase.DrawAI();
        SoundManager.instance.PlaySingle(aiPlayCardSound);
    }

    void Update() {

        if (Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(r, Input.mousePosition))
        {
            startTouchPos = Input.mousePosition;
            isStartedTouchPanel = true;
        }

        if (Input.GetMouseButtonUp(0) && isStartedTouchPanel)
        {
            isStartedTouchPanel = false;
            Vector3 d = Input.mousePosition - startTouchPos;
            if (d.sqrMagnitude == 0)
            {
                if (shownCard.Card != null) { shownCard.Card.OnPlay(); }
                shownCard.Card = null;
                GameController.INSTANCE.NextState();

                return;
            }
        }
    }
}