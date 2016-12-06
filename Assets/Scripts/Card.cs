using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

public class LexCard {
    public enum Type { PLAYER, AI };

    protected const string imagePath = "Cards/images/";
    protected const string flowchartPath = "Cards/effects/";
    protected const string backgroundPath = "Cards/backgrounds/";

    [XmlElement("Name")]
    public string Name { get; private set; }

    [XmlElement("Description")]
    public string Description { get; private set; }

    [XmlElement("Week")]
    public int week { get; private set; }

    [XmlElement("RefName")]
    public string refName { get; private set; }

    [XmlElement("Terrain")]
    public string terrainString { get; private set; }

    [XmlElement("DayPhase")]
    public string dayPhaseString { get; private set; }

    [XmlElement("Count")]
    public int count { get; private set; }

    public void Copy (LexCard card) {
        Name = card.Name;
        Description = card.Description;
        week = card.week;
        refName = card.refName;
        terrainString = card.terrainString;
        dayPhaseString = card.dayPhaseString;
        count = card.count;
    }
}

public class Card : LexCard {
    private List<GameController.Terrain> terrain = new List<GameController.Terrain>();
    private List<GameController.DayTime> dayPhase = new List<GameController.DayTime>();

    public Sprite Image { get; private set; }
    public Sprite Background { get; private set; }
    public new Type Type { get; private set; }
    public Fungus.Flowchart cardEffectsOnPlay { get; private set; }

    public Card (LexCard card, Type type) {
        Copy(card);
        Type = type;
        Image = Resources.Load<Sprite>(imagePath + refName);
        cardEffectsOnPlay = Resources.Load<Fungus.Flowchart>(flowchartPath + refName);
        
        ParseTerrain();
        ParseDayPhase();
        SetBackground();
    }

    private void ParseTerrain () {
        string[] terrains = terrainString.Split(',');

        foreach (string t in terrains) {
            switch (t.Trim()) {
                case "Any":
                    terrain.Add(GameController.Terrain.Forests);
                    terrain.Add(GameController.Terrain.Caves);
                    terrain.Add(GameController.Terrain.Hills);
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
    }

    private void ParseDayPhase () {
        string[] times = dayPhaseString.Split(',');

        foreach (string t in times) {
            switch (t.Trim()) {
                case "Any":
                    dayPhase.Add(GameController.DayTime.Dawn);
                    dayPhase.Add(GameController.DayTime.Dusk);
                    dayPhase.Add(GameController.DayTime.Night);
                    break;
                case "Morning":
                    dayPhase.Add(GameController.DayTime.Dawn);
                    break;
                case "Afternoon":
                    dayPhase.Add(GameController.DayTime.Dusk);
                    break;
                case "Night":
                    dayPhase.Add(GameController.DayTime.Night);
                    break;
            }
        }
    }

    private void SetBackground () {
        if (terrain.Count > 0) {
            string bg = (Type == Type.AI) ? "AICard_" : "cardformat_";
            switch (terrain[0]) {
                case GameController.Terrain.Forests:
                    bg += "forest";
                    break;
                case GameController.Terrain.Caves:
                    bg += "caves";
                    break;
                case GameController.Terrain.Hills:
                    bg += "hills";
                    break;
                case GameController.Terrain.Swamps:
                    bg += "swamps";
                    break;
            }
            Background = Resources.Load<Sprite>(backgroundPath + bg);
        }
    }

    /// <summary>
    /// Called when the hand object plays a card
    /// </summary>
    public void OnPlay() {
        if (cardEffectsOnPlay != null) {
            Object.Instantiate(cardEffectsOnPlay);
        }
    } 

    /// <summary>
    /// Return true if the card can be played on the current turn.
    /// </summary>
    public bool isCurrentlyPlayable() {
         return (terrain.Contains(GameController.INSTANCE.currentTerrain)
                 && dayPhase.Contains(GameController.INSTANCE.currentDayTime));
    }

    /// <summary>
    /// Check whether this card should be in the deck at this point in the game.
    /// </summary>
    public bool isInPlay() {
        return (GameController.INSTANCE.week >= week && week > -1);
    }
}