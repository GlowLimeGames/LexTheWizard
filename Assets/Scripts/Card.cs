using UnityEngine;
using System.Collections;

public class Card {
    private string name;
    private string description;
    private Sprite image;

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public Sprite Image { get { return image; } }

    public Card (string n, string d, Sprite s) {
        name = n;
        description = d;
        image = s; 
    }
}