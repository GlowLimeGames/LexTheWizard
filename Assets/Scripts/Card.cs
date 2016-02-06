using UnityEngine;
using System.Collections;

public class Card {

	public int cardNumber;

	string title;
    string terrain;
    string desc1;
    string desc2;

    int gold;
    int salvage;

    Sprite art;

    public void Init(string title, string terrain, string desc1, string desc2, int gold, int salvage, Sprite art)
    {
        this.title = title;
        this.terrain = terrain;
        this.desc1 = desc1;
        this.desc2 = desc2;
        this.gold = gold;
        this.salvage = salvage;
        this.art = art;
    }
}
