using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Card : MonoBehaviour {
    public const string imagePath = "Cards/";

    private string name;
    private string description;
    private Sprite image;
    private int dayAdded;
    private HashSet<GameController.Terrain> terrain = new HashSet<GameController.Terrain>();
    private HashSet<GameController.DayTime> dayTime = new HashSet<GameController.DayTime>();

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public Sprite Image { get { return image; } }

    public Fungus.Flowchart cardEffectsOnPlay;

    public void Init(LexCard card) {
        name = card.CardName;
        description = card.CardText;
        image = Resources.Load<Sprite>(imagePath + card.CardImageName);
        dayAdded = card.DayAdded;

        string[] times = card.DayPhase.Split(',', ' ');
        string[] terrains = card.Terrain.Split(',', ' ');

        foreach (string t in terrains) {
            Debug.Log("Adding terrain [" + t + "] to " + name);
            switch (t) {
                case "Any":
                    terrain.Add(GameController.Terrain.Caves);
                    terrain.Add(GameController.Terrain.Hills);
                    terrain.Add(GameController.Terrain.Forests);
                    terrain.Add(GameController.Terrain.Swamps);
                    break;
                case "Cave":
                    terrain.Add(GameController.Terrain.Caves);
                    break;
                case "Hills":
                    terrain.Add(GameController.Terrain.Hills);
                    break;
                case "Forest":
                    terrain.Add(GameController.Terrain.Forests);
                    break;
                case "Swamp":
                    terrain.Add(GameController.Terrain.Swamps);
                    break;
            }
        }

        foreach (string t in times) {
            switch (t) {
                case "Any":
                    dayTime.Add(GameController.DayTime.Dawn);
                    dayTime.Add(GameController.DayTime.Dusk);
                    dayTime.Add(GameController.DayTime.Night);
                    break;
                case "Morning":
                    dayTime.Add(GameController.DayTime.Dawn);
                    break;
                case "Afternoon":
                    dayTime.Add(GameController.DayTime.Dusk);
                    break;
                case "Night":
                    dayTime.Add(GameController.DayTime.Night);
                    break;
            }
        }

        foreach (GameController.Terrain t in terrain) {
            Debug.Log(t);
        }
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
    public bool isCurrentlyPlayable() {
        Debug.Log("Terrains:");
        foreach (GameController.Terrain t in terrain) {
            Debug.Log(t);
        }

        bool playable = (terrain.Contains(GameController.INSTANCE.currentTerrain)
                && dayTime.Contains(GameController.INSTANCE.currentDayTime));
        // if (!playable) { Debug.Log("Filtering out unplayable card: " + name); }
        return true;
    }

    /// <summary>
    /// TBD: check whether this card should be in the
    /// deck at this point in the game.
    /// </summary>
    public bool isInPlay() {
        return (GameController.INSTANCE.dayCount >= dayAdded);
    }

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

    [XmlElement("Terrain")]
    public string Terrain;

    [XmlElement("DayPhase")]
    public string DayPhase;

    [XmlElement("DayAdded")]
    public int DayAdded;
}