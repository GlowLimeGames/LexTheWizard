using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardViewer : MonoBehaviour {
    public Text cardName;
    public Text description;
    public Text info;
    public Image image;
    public Image background;
    
    private Card card;

    public Card Card {
        get { return card; }
        set {
            card = value;

            if (card != null) {
                Show(true);
                UpdateCard();
            }
            else {
                Show(false);
            }
        }
    }

    void Start () {
        Show(card != null);
    }

    public void Show (bool show) {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(show);
        }
    }

    private void UpdateCard() {
        cardName.text = card.Name;
        description.text = card.Description;
        if (info != null) { info.text = card.info; }
        if (image != null) { image.sprite = card.Image; }
        background.sprite = card.Background;
    }
}