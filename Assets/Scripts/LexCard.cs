using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class LexCard : MonoBehaviour{
    [XmlElement("CardName")]
    public string CardName;

    [XmlElement("CardText")]
    public string CardText;

    [XmlElement("CardImage")]
    public string CardImageName;

    public Fungus.Flowchart cardEffectsOnPlay;

    public LexCard() { }


    /// <summary>
    /// Called when the hand object plays a card
    /// </summary>
    public void OnPlay() {
        if(cardEffectsOnPlay != null) {
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

    /// <summary>
    /// TBD: check whether this is an AI card or a
    /// player card
    /// </summary>
    public bool isAI() { return false; }
}