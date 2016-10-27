﻿using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class Card : MonoBehaviour {
    private string name = "untitled";
    // public string Name { get; }
    private string description = "description";

    public Fungus.Flowchart cardEffectsOnPlay;

    public void Init (LexCard card) {

    }

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

public class LexCard {
    [XmlElement("CardName")]
    public string CardName;

    [XmlElement("CardText")]
    public string CardText;

    [XmlElement("CardImage")]
    public string CardImageName;
}