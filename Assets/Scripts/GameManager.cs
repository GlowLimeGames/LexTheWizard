using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject cardPopup;

    SpriteRenderer cardRend;

    void Awake()
    {
        cardPopup.GetComponent<SpriteRenderer>().enabled = false;
    }
}
