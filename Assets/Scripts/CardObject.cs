using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardObject : MonoBehaviour {

    Text titleText;
    Text goldText;
    Text salvageText;
    Text description1;
    Text description2;

    float scaleFactor;

    Vector3 scaleVector;
    Image image;
    CardInfo myInfo;

    Tuning tuning;

    void Start()
    {
        tuning = Tuning.tuning;
        scaleFactor = tuning.scaleFactor;
        scaleVector = new Vector3(scaleFactor, scaleFactor);
    }

    public void CreateCard(CardInfo cardInfo)
    {
        myInfo = cardInfo;

        image = GetComponentInChildren<Image>();
        image.sprite = cardInfo.art;

        // Set up references to Text components
        Text[] text = GetComponentsInChildren<Text>();
        titleText = text[0];
        goldText = text[1];
        salvageText = text[2];
        description1 = text[3];
        description2 = text[4];

        // Assign strings to Text components
        titleText.text = cardInfo.title + " " + cardInfo.terrain;
        goldText.text = cardInfo.gold.ToString();
        salvageText.text = cardInfo.salvage.ToString();
        description1.text = cardInfo.desc1;
        description2.text = cardInfo.desc2;
        
        Debug.Log("A card has been created");
    }

    void OnMouseDown()
    {
        transform.localScale += scaleVector;
    }

    void OnMouseUp()
    {
        transform.localScale -= scaleVector;
    }
}

