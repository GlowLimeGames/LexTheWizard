using UnityEngine;
using System.Collections;

public class ConfirmationPopup : Popup
{

    Player player;
    string action; // Either play or discard

    void Start()
    {
        player = Player.player;
    }

    public void ConfirmAction(bool confirm)
    {
        if (confirm)
        {
            if (action == "play")
            {
                player.Confirm(true);
            }
            else if (action == "discard")
            {

            }
            Debug.Log("Confirmed.");
        }
        else
        {
            Debug.Log("Cancelled.");
            player.Confirm(false);
        }
        Hide();
    }

    public void SetAction(string action)
    {
        this.action = action;
        SetText("Are you sure you want to " + action + " " + player.SelectedCard.name + "?");
    }
}
