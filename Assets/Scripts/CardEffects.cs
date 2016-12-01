using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CardEffects : MonoBehaviour {
    /// <summary>
    /// Access to the active Hand object so we
    /// can draw & discard cards.
    /// </summary>
    private Hand hand {
        get {
            if (hand == null) {
                hand = FindObjectOfType<Hand>();
            }
            return hand;
        }
        set { hand = value; }
    }

    /// <summary>
    /// Returns the amount of mana the player currently has.
    /// </summary>
    public int getCurrentMana () {
        return GameController.INSTANCE.Mana;
    }

    /// <summary>
    /// Returns the number of points the player currently has.
    /// </summary>
    public int getCurrentPoints () {
        return GameController.INSTANCE.Points;
    }

    /// <summary>
    /// Returns a float value between 0 and 1.
    /// </summary>
    public float getRandomPercent () {
        return Random.Range(0f, 1f);
    }

    /// <summary>
    /// Changes the number of points that the player has by i
    /// </summary>
    /// <param name="i">How many points are given, negative numbers subtract points</param>
	public void ChangePoints(int points) {
        GameController.INSTANCE.Points += points;
	}

    /// <summary>
    /// Changes the amount of mana the player has by i
    /// </summary>
    /// <param name="i">How much mana is given, negative numbers subtract mana</param>
    public void ChangeMana(int mana) {
        GameController.INSTANCE.Mana += mana;
    }

    /// <summary>
    /// Moves the player to a random terrain.
    /// </summary>
    public void RandomTerrain() {
        UpdateTerrainState.RandomTerrain();
    }

    /// <summary>
    /// Moves the player to the specified terrain.
    /// </summary>
    public void MoveToTerrain(GameController.Terrain terrain) {
        UpdateTerrainState.MoveToTerrain(terrain);
    }

    /// <summary>
    /// Draws cards until the hand is full.
    /// </summary>
    /// <returns>The number of cards drawn</returns>
    public int DrawCards() { return hand.Draw(); }

    /// <summary>
    /// Draws the specified number of cards, or until
    /// the hand is full - whichever comes first.
    /// </summary>
    /// <returns>The number of cards drawn</returns>
    public int DrawCards(int numberOfCards) {
        return hand.Draw(numberOfCards);
    }

    /// <summary>
    /// Discards cards until the hand is empty.
    /// </summary>
    /// <returns>The number of cards discarded</returns>
    public int DiscardCards() { return hand.Discard(); }

    /// <summary>
    /// Discards the specified number of cards, or until
    /// the hand is empty - whichever comes first.
    /// </summary>
    /// <returns>The number of cards discarded</returns>
    public int DiscardCards(int numberOfCards) {
        return hand.Discard(numberOfCards);
    }

    /// <summary>
    /// Should be called from the flowchart whenever the dialog finishes
    /// Makes the canvas active again
    /// </summary>
    public void ToggleCanvas(bool isOn)
    {
        GameController.INSTANCE.canvas.SetActive(isOn);
    }
}
