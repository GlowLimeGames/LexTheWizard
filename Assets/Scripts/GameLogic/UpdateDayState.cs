using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UpdateDayState : MonoBehaviour{

    [SerializeField]
    private Image dayIcon;

    [SerializeField]
    private Text dayCount;

    public Sprite daySprite;
    public Sprite afternoonSprite;
    public Sprite nightSprite;


    void OnEnable()
    {
        Fungus.Flowchart.BroadcastFungusMessage("UpdateDayStateStart");
    }

    void Update()
    {
		// Assume that any dialogue card shown in the previous turn is now dismissed
		EventController.Event(Event.DIALOGUE_CARD_DISMISSED);
        GameController.instance.currentDayTime++;
        if ((int)GameController.instance.currentDayTime >= System.Enum.GetValues(typeof(GameController.DayTime)).Length)
        {
            GameController.instance.currentDayTime = 0;
            GameController.instance.dayCount++;

        }

        switch (GameController.instance.currentDayTime)
        {
            case GameController.DayTime.Morning:
                dayIcon.sprite = daySprite;
                break;
            case GameController.DayTime.Afternoon:
                dayIcon.sprite = afternoonSprite;
                break;
            case GameController.DayTime.Night:
                dayIcon.sprite = nightSprite;
                break;
            default:
                break;
        }

        dayCount.text = "" + GameController.instance.dayCount;
        GameController.instance.NextState();

        CardDatabase.UpdateDecks();
    }

}
