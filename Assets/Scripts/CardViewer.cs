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
                Show(false);
            }
        }
    }


    void Start () {
        Show(card != null);
    }
	

	private void UpdateCard (GameObject newCard) {
        newCard.transform.SetParent(gameObject.transform);
        newCard.GetComponent<RectTransform>().localPosition = new Vector3();
        newCard.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

    }


    public void Show (bool show) {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(show);
        }
    }
}