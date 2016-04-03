using UnityEngine;
using System.Collections;

public class ConfirmationPopup : Popup
{

    UIManager UImanager;
    DiscardPile discard;
    Player player;
    string action; // Either play or discard

    void Start()
    {
        player = Player.player;
        UImanager = UIManager.UImanager;
        discard = UImanager.Discard;
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
                if (discard == null)
                {
                    discard = UImanager.Discard;
                }
                discard.Discard();
            }
            Debug.Log("Confirmed.");
            UImanager.ShowActionIcons(false);
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
        gameObject.SetActive(true);
        SetText("Are you sure you want to " + action + " " + player.SelectedCard.GetCardInfo().title + "?");
    }
}
