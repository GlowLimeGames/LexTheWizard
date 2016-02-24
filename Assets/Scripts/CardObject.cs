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
    Text terrainText;
    Text cardTypeText;
    Text goldText;
    Text pointsText;
    Text salvageText;
    Text description;
	Image art;
	Image backgroundImage;
    //SpriteRenderer rend;

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
    bool inHand;
    bool played; // Whether the card has been played
    bool hasShrunk;

    CardInfo myCardInfo;

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
        //rend = GetComponent<SpriteRenderer>();
	}

    // This function is called from CardGame
    // A CardObject is created from the variables in CardInfo
    public void CreateCard(CardInfo cardInfo)
    {
        myCardInfo = cardInfo;
		Image[] images = GetComponentsInChildren<Image> ();
        // Set up reference to Image component in Children
        art = images[1];
		// Assign a sprite to that image
	    art.sprite = cardInfo.art;

        // Set up references to Text components in Children
        Text[] text = GetComponentsInChildren<Text>();
        titleText = text[0];
        terrainText = text[1];
        cardTypeText = text[2];
        goldText = text[3];
        pointsText = text[4];
        salvageText = text[5];
        description = text[6];

        // Assign strings to Text components
        titleText.text = cardInfo.title;
        terrainText.text = cardInfo.terrain;
        cardTypeText.text = cardInfo.cardType;
        goldText.text = cardInfo.gold.ToString();
        pointsText.text = cardInfo.points.ToString();
        salvageText.text = cardInfo.salvage.ToString();
        description.text = cardInfo.desc;

		Land terrain = GameController.gameController.GetTerrainByName (cardInfo.terrain);
		backgroundImage = images [0];
		SetBackgroundImage (terrain.cardArt);
    }

	public void SetBackgroundImage(Sprite sprite) {
		backgroundImage.sprite = sprite;
	}

    // This is called from CardGame when cards are dealt
    public void SetOwner(CardPlayer cardPlayer)
    {
        owner = cardPlayer;
		inHand = true;
    }

    public CardInfo GetCardInfo()
    {
        return myCardInfo;
    }

    void OnMouseDown() {
        Grow();
        // Push to front
        transform.SetAsLastSibling();
        //rend.sortingOrder = 1;

        // Assign screenPoint and offset in case user will drag the mouse
        screenPoint = mainCam.WorldToScreenPoint(gameObject.transform.position);
        //mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        offset = gameObject.transform.position - mainCam.ScreenToWorldPoint(getMousePosition());
    }

    void OnMouseUp() {
        Shrink();
        //rend.sortingOrder = 0;
        if (!inHand && !played)
        { // If card hasn't been played yet and is on the board
			checkOwner();
			owner.PlayCard(this);
            played = true;
        }
    }

    public void Grow()
    {
        transform.localScale = tuning.cardScale + scaleVector;
        hasShrunk = false;
    }

    public void Shrink()
    {
        transform.localScale = tuning.cardScale;
        hasShrunk = true;
    }

	void checkOwner () {
		if (owner == null) {
			if (myCardInfo.deckType == DeckType.AI) {

				owner = CardGame.Instance.enemy;

			} else if (myCardInfo.deckType == DeckType.Player) {

				owner = CardGame.Instance.player;

			}
		}
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
            case "Hand":
                inHand = true;
                break;
            case "Discard":
                //Shrink();
                break;
        }  
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        string colTag = coll.gameObject.tag;
        switch (colTag)
        {
            case "Hand":
                inHand = true;
                break;
            case "Discard":
                if (!hasShrunk)
                {
                    //Shrink();
                }
                break;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        string colTag = coll.gameObject.tag;
        switch(colTag)
        {
            case "Hand":
                inHand = false;
                break;
            case "Discard":
                //Grow();
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

