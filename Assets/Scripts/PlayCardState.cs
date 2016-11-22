using UnityEngine;
using System.Collections;
using System;

public class PlayCardState : MonoBehaviour{

    Vector3 startTouchPos;
    public Hand hand;
    float distsq = 4000f;
    public CardViewer currentCard;
    public int swipeSpeed = 200;

    void OnEnable()
    {
        Fungus.Flowchart.BroadcastFungusMessage("PlayCardStateStart");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 d = Input.mousePosition - startTouchPos;
            if (d.sqrMagnitude > distsq)
            {
                if(Math.Abs(d.x) > Math.Abs(d.y))
                {
                    //Horizontal swipe
                    if(d.x < 0)
                    {
                        StartCoroutine("SwipeLeft");
                    }
                    else
                    {
                        StartCoroutine("SwipeRight");
                    }
                }
                else
                {
                    //Vertical swipe
                    if (d.y < 0)
                    {
                        StartCoroutine("ScrapCard");
                    }
                    else
                    {
                        StartCoroutine("PlayCard");
                    }
                }
            }
        }
    }

    public void NextButton()
    {
        GameController.INSTANCE.NextState();
    }

    IEnumerator SwipeLeft()
    {
        float xPos = currentCard.GetComponent<RectTransform>().anchoredPosition.x;
        float yPos = currentCard.GetComponent<RectTransform>().anchoredPosition.y;

        while (xPos > -800)
        {
            currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos - swipeSpeed, yPos);
            xPos = currentCard.GetComponent<RectTransform>().anchoredPosition.x;
            yield return null;
        }

        hand.PreviousCard();
        currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(800, yPos);

        xPos = currentCard.GetComponent<RectTransform>().anchoredPosition.x;
        while (xPos > 0)
        {
            currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos - swipeSpeed, yPos);
            xPos = currentCard.GetComponent<RectTransform>().anchoredPosition.x;
            yield return null;
        }

        currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, yPos);
    }

    IEnumerator SwipeRight()
    {
        float xPos = currentCard.GetComponent<RectTransform>().anchoredPosition.x;
        float yPos = currentCard.GetComponent<RectTransform>().anchoredPosition.y;

        while (xPos < 800)
        {
            currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos + swipeSpeed, yPos);
            xPos = currentCard.GetComponent<RectTransform>().anchoredPosition.x;
            yield return null;
        }

        hand.NextCard();
        currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(-800, yPos);

        xPos = currentCard.GetComponent<RectTransform>().anchoredPosition.x;
        while (xPos < 0)
        {
            currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos + swipeSpeed, yPos);
            xPos = currentCard.GetComponent<RectTransform>().anchoredPosition.x;
            yield return null;
        }

        currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, yPos);
    }

    IEnumerator PlayCard()
    {
        float xPos = currentCard.GetComponent<RectTransform>().anchoredPosition.x;
        float yPos = currentCard.GetComponent<RectTransform>().anchoredPosition.y;

        while (yPos < 800)
        {
            currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos + swipeSpeed);
            yPos = currentCard.GetComponent<RectTransform>().anchoredPosition.y;
            yield return null;
        }

        hand.PlayCard();
        currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    IEnumerator ScrapCard()
    {
        float xPos = currentCard.GetComponent<RectTransform>().anchoredPosition.x;
        float yPos = currentCard.GetComponent<RectTransform>().anchoredPosition.y;

        while (yPos > -800)
        {
            currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos - swipeSpeed);
            yPos = currentCard.GetComponent<RectTransform>().anchoredPosition.y;
            yield return null;
        }

        hand.SalvageCard();
        currentCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
}
