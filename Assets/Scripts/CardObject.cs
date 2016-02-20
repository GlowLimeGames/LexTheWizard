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

    CardPlayer owner; // Who has this card in their hand, if anyone

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
    bool played; // Whether the card has been played

    CardInfo myCardInfo;

    // Reference to Tuning object
    Tuning tuning;

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
        myCardInfo = cardInfo;

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

    // This is called from CardGame when cards are dealt
    public void SetOwner(CardPlayer cardPlayer)
    {
        owner = cardPlayer;
    }

    public CardInfo GetCardInfo()
    {
        return myCardInfo;
    }

    void OnMouseDown() {
        Grow();
        // Push to front
        transform.SetAsLastSibling();

        // Assign screenPoint and offset in case user will drag the mouse
        screenPoint = mainCam.WorldToScreenPoint(gameObject.transform.position);
        //mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        offset = gameObject.transform.position - mainCam.ScreenToWorldPoint(getMousePosition());
    }

    void OnMouseUp() {
        Shrink();

        if (!played)
        { // If card hasn't been played yet
            owner.PlayCard(this);
            played = true;
        }
    }

    void Grow()
    {
        transform.localScale += scaleVector;
    }

    void Shrink()
    {
        transform.localScale -= scaleVector;
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
        string colTag = coll.gameObject.tag;
        switch (colTag)
        {
            case "Board":
                touchingBoard = true;
                break;
            case "Discard":
                Shrink();
                break;
        }  
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        string colTag = coll.gameObject.tag;
        switch(colTag)
        {
            case "Board":
                touchingBoard = false;
                break;
            case "Discard":
                Grow();
                break;
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

