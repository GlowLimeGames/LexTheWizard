using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour{

    public Fungus.Flowchart cardEffectsOnPlay;


    /// <summary>
    /// Called when the hand object plays a card
    /// </summary>
    public void OnPlay()
    {
        if(cardEffectsOnPlay != null)
        {
            Instantiate(cardEffectsOnPlay);
        }
    } 

    /// <summary>
    /// TBD: Return true if the card can be played on the
    /// current turn.
    /// </summary>
    public bool isCurrentlyPlayable() { return true; }

    /// <summary>
    /// TBD: check whether this card should be in the
    /// deck at this point in the game.
    /// </summary>
    public bool isInPlay() { return true; }
}