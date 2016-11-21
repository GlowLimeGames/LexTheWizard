using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Card : MonoBehaviour {
    public const string imagePath = "Cards/";
    public const string flowchartPath = "Flowcharts/";

    private string name;
    private string description;
    private Sprite image;
    private Sprite background;
    private int week;
    private List<GameController.Terrain> terrain = new List<GameController.Terrain>();
    private List<GameController.DayTime> dayTime = new List<GameController.DayTime>();

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public Sprite Image { get { return image; } }
    public CardType Type { get; set; }

    public List<Fungus.Flowchart> cardEffectsOnPlay;

    public enum CardType { Player, AI };

    public Card (LexCard card) { Init(card); }

    public void Init(LexCard card) {
        name = card.CardName;
        description = card.CardText;
        image = Resources.Load<Sprite>(imagePath + card.CardImageName);
        week = card.Week;

        string[] flowcharts = card.Flowchart.Split(',', ' ');
        string[] times = card.DayPhase.Split(',', ' ');
        string[] terrains = card.Terrain.Split(',', ' ');

        cardEffectsOnPlay = new List<Fungus.Flowchart>();
        foreach (string flowchart in flowcharts) {
            if (flowchart.Length > 0) {
                cardEffectsOnPlay.Add(Resources.Load<Fungus.Flowchart>(flowchartPath + flowchart));
            }
        }

        foreach (string t in terrains) {
            switch (t) {
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
    }

    /// <summary>
    /// Called when the hand object plays a card
    /// </summary>
    public void OnPlay() {
        foreach (Fungus.Flowchart effect in cardEffectsOnPlay) {
            Instantiate(effect);
        }
    } 

    /// <summary>
    /// TBD: Return true if the card can be played on the
    /// current turn.
    /// </summary>
    public bool isCurrentlyPlayable() {
        return (terrain.Contains(GameController.INSTANCE.currentTerrain)
                && dayTime.Contains(GameController.INSTANCE.currentDayTime));
    }

    /// <summary>
    /// TBD: check whether this card should be in the
    /// deck at this point in the game.
    /// </summary>
    public bool isInPlay() {
        return (GameController.INSTANCE.week >= week);
    }

    /// <summary>
    /// TBD: check whether this is an AI card or a
    /// player card
    /// </summary>
    public bool isAI() {
        return Type == CardType.AI;
    }
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

    [XmlElement("Week")]
    public int Week;

    [XmlElement("Flowchart")]
    public string Flowchart;
}