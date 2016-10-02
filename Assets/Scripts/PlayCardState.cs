using UnityEngine;
using System.Collections;
using System;

public class PlayCardState : MonoBehaviour{

    void Update()
    {

    }

    public void NextButton()
    {
        GameController.INSTANCE.Card1 = null;
        GameController.INSTANCE.Card2 = null;
        GameController.INSTANCE.Card3 = null;
        GameController.INSTANCE.NextState();
    }

    public void PlayCard(int card)
    {
        if(card == 1 && GameController.INSTANCE.Card1 != null)
        {
            GameController.INSTANCE.Card1 = null;
            GameController.INSTANCE.Points++;
        }
        else if(card == 2 && GameController.INSTANCE.Card2 != null)
        {
            GameController.INSTANCE.Card2 = null;
            GameController.INSTANCE.Points++;
        }
        else if(card == 3 && GameController.INSTANCE.Card3 != null)
        {
            GameController.INSTANCE.Card3 = null;
            GameController.INSTANCE.Points++;
        }
    }

    public void ScrapCard(int card)
    {
        if (card == 1 && GameController.INSTANCE.Card1 != null)
        {
            GameController.INSTANCE.Card1 = null;
            GameController.INSTANCE.Mana++;
        }
        else if (card == 2 && GameController.INSTANCE.Card2 != null)
        {
            GameController.INSTANCE.Card2 = null;
            GameController.INSTANCE.Mana++;
        }
        else if (card == 3 && GameController.INSTANCE.Card3 != null)
        {
            GameController.INSTANCE.Card3 = null;
            GameController.INSTANCE.Mana++;
        }
    }
}
