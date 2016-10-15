using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardViewer : MonoBehaviour {
    
    private GameObject card;

    public GameObject Card {
        get { return card; }
        set {
            card = value;

            if (card != null) {
                UpdateCard(value);
                Show(true);
            }
            else {
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
                Show(false);
            }
        }
    }


    void Start () {
        Show(card != null);
    }
	

	private void UpdateCard (GameObject newCard) {
        newCard.transform.SetParent(gameObject.transform);
        newCard.GetComponent<RectTransform>().anchorMin = new Vector2();
        newCard.GetComponent<RectTransform>().anchorMax = new Vector2(1,1);
        newCard.GetComponent<RectTransform>().offsetMax = new Vector2();
        newCard.GetComponent<RectTransform>().offsetMin = new Vector2();

    }


    public void Show (bool show) {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(show);
        }
    }
}