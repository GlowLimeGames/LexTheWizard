/*
 * using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour {

    public GameObject cardPopup;
    public Text titleText;
    public Text goldText;
    public Text salvageText;
    public Text description1;
    public Text description2;

    SpriteRenderer cardRend;

    string title;
    string terrain;
    string desc1;
    string desc2;

    int gold;
    int salvage;

    Sprite art;

    void Awake()
    {
        cardRend = cardPopup.GetComponent<SpriteRenderer>();
    }

    public Card(string title, string terrain, int gold, int salvage, Sprite art, string desc1, string desc2)
    {
        this.title = title;
        this.terrain = terrain;
        this.desc1 = desc1;
        this.desc2 = desc2;
        this.gold = gold;
        this.salvage = salvage;
        this.art = art;
    }

    // For testing cards without art
    public Card(string title, string terrain, int gold, int salvage, string desc1, string desc2)
    {
        this.title = title;
        this.terrain = terrain;
        this.desc1 = desc1;
        this.desc2 = desc2;
        this.gold = gold;
        this.salvage = salvage;
    }

    public void ShowDetails()
    {
        titleText.text = title + " " + terrain;
        goldText.text = gold.ToString();
        salvageText.text = salvage.ToString();
        description1.text = desc1;
        description2.text = desc2;
    }

    void OnMouseDown()
    {
        cardRend.enabled = true;
    }

    void OnMouseUp()
    {
        cardRend.enabled = false;
    }
}
*/