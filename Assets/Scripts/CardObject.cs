/*
 * Attached to an Instantiated Card Prefab from CardGame.cs
 * 
 * Controls UI components displayed on the card (text, image)
 * This information is determined by CardInfo
 * 
 * Describes user interaction, such as changing scale on MouseDown and MouseUp
 * Script for click and drag: http://answers.unity3d.com/questions/12322/drag-gameobject-with-mouse.html
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardObject : MonoBehaviour {

    // text asset variable to assign the text file to
    public TextAsset testFile;

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

    // Variables for click and drag
    Camera mainCam;
    Vector3 screenPoint;
    Vector3 offset;
    Vector3 mousePosition;

    // Variable for handling collisions
    bool touchingBoard;
    
	// Reference to this object's CardInfo
    //CardInfo myInfo;

	// Reference to Tuning object
    Tuning tuning;

	//Usability variables: Indices correspond to enums for time and terrain. 0 means not usable 1 means usable.
	int[] terrainUse = new int[4];
	int[] timeUse = new int[4];

    void Start()
    {
        tuning = Tuning.tuning;
        mainCam = Camera.main;
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

    void PlayCard()
    {
        Debug.Log("This card has been played");
    }

	void OnMouseDown() {
		// Grow
		transform.localScale += scaleVector;
		// Push to front
		transform.SetAsLastSibling();

        // Assign screenPoint and offset in case user will drag the mouse
        screenPoint = mainCam.WorldToScreenPoint(gameObject.transform.position);
        //mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        offset = gameObject.transform.position - mainCam.ScreenToWorldPoint(getMousePosition());
	}

	void OnMouseUp() {
		// Shrink
		transform.localScale -= scaleVector;

        PlayCard();
	}

    void OnMouseDrag()
    {
        transform.position = mainCam.ScreenToWorldPoint(getMousePosition()) + offset;
    }

    Vector3 getMousePosition()
    {
        return new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Board")
        {
            touchingBoard = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Board")
        {
            touchingBoard = false;
        }
    }

	//Function to read lines from a text file asset
	 void readTextFile()
	{
		//splits each line into a spot in an array
		string[] linesInFile = testFile.text.Split ('\n');
		//prints each line to the console
		//foreach (string line in linesInFile) {
		//	print (line);
		//}
	}
	//function to read a particular line from a file by searching for it with substring lineStart
	void readLineFromFile(string lineStart)
	{
		//splits each line into a spot in an array
		string[] linesInFile = testFile.text.Split ('\n');
		foreach (string line in linesInFile) {
			//searches each index for substring lineStart
			if (line.Contains (lineStart))
			{
				print (line);
			}
		}
	}
}

