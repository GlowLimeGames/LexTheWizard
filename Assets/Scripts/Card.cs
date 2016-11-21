using UnityEngine;
using System.Collections.Generic;

public class Card {
    public const string imagePath = "Cards/images/{0}.png";
    public const string flowchartPath = "Cards/effects";

    private string name;
    private string description;
    private Sprite image;
    private Sprite background;
    private int week = 0;
    private List<GameController.Terrain> terrain = new List<GameController.Terrain>();
    private List<GameController.DayTime> dayTime = new List<GameController.DayTime>();

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public Sprite Image { get { return image; } }
    public CardType Type { get; set; }

    public Fungus.Flowchart cardEffectsOnPlay;

    public enum CardType { Player, AI };

    public Card (LexCard card) {
        name = card.CardName;
        description = card.CardText;
        image = Resources.Load<Sprite>(string.Format(imagePath, card.CardImageName));
        week = card.Week;
        
        string[] times = card.DayPhase.Split(',', ' ');
        string[] terrains = card.Terrain.Split(',', ' ');
       
        cardEffectsOnPlay = Resources.Load<Fungus.Flowchart>(flowchartPath + card.Flowchart);

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
        if (cardEffectsOnPlay != null) {
            Object.Instantiate(cardEffectsOnPlay);
        }
    } 

    /// <summary>
    /// Return true if the card can be played on the current turn.
    /// </summary>
    public bool isCurrentlyPlayable() {
        return (terrain.Contains(GameController.INSTANCE.currentTerrain)
                && dayTime.Contains(GameController.INSTANCE.currentDayTime));
    }

    /// <summary>
    /// Check whether this card should be in the deck at this point in the game.
    /// </summary>
    public bool isInPlay() {
        return GameController.INSTANCE.week >= week;
    }

    /// <summary>
    /// Check whether this is an AI card or a player card
    /// </summary>
    public bool isAI() {
        return Type == CardType.AI;
    }
}