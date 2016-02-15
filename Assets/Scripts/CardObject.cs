/*
 * Attached to an Instantiated Card Prefab from CardGame.cs
 * 
 * Controls UI components displayed on the card (text, image)
 * This information is determined by CardInfo
 * 
 * Describes user interaction, such as changing scale on MouseDown and MouseUp
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardObject : MonoBehaviour {

	// UI Components
    Text titleText;
    Text goldText;
    Text salvageText;
    Text description1;
    Text description2;
	Image image;

	// Variables to control card scale
    float scaleFactor;
    Vector3 scaleVector;
    
	// Reference to this object's CardInfo
    //CardInfo myInfo;

	// Reference to Tuning object
    Tuning tuning;

    void Start()
    {
        tuning = Tuning.tuning;
        scaleFactor = tuning.scaleFactor; // Get scale factor from tuning object
        scaleVector = new Vector3(scaleFactor, scaleFactor); // Great scale vector using scale factor
    }

	// This function is called from CardGame
	// A CardObject is created from the variables in CardInfo
    public void CreateCard(CardInfo cardInfo)
    {
        //myInfo = cardInfo;

		// Set up reference to Image component in Children
        image = GetComponentInChildren<Image>();
		// Assign a sprite to that image
        image.sprite = cardInfo.art;

        // Set up references to Text components in Children
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
    }

	void OnMouseDown() {
		// Grow
		transform.localScale += scaleVector;
		// Push to front
		transform.SetAsLastSibling();
	}

	void OnMouseUp() {
		// Shrink
		transform.localScale -= scaleVector;
	}
}

