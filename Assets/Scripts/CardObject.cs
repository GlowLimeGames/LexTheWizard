/*
 * Attached to an Instantiated Card Prefab from CardGame.cs
 * 
 * Controls UI components displayed on the card (text, image)
 * This information is determined by CardInfo
 * 
 * Describes user interaction, such as changing scale on MouseDown and MouseUp
 * 
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardObject : MonoBehaviour {

    protected Player player;
    protected UIManager UImanager;

    // UI Components
    protected Text[] text;
    protected Text titleText;
    protected Text terrainText;
    protected Text cardTypeText;
    protected Text description;
    protected Image[] images;
    protected Sprite cardBackground;
    protected ClickManager clickManager;

    protected CardPlayer owner; // Who has this card in their hand, if anyone
    protected Land[] acceptedTerrains; // Terrains this card can be played on

	protected bool locked; // Whether the card is interactable

    Vector3 scaleVector; // Variable to control card scale when pressed

    // Variable for handling collisions
    protected bool inHand; // Whether the card is in a card player's hand
    protected bool played; // Whether the card has been played
    protected bool touchingBoard;
    protected bool hasShrunk;
    protected Vector3 lastPosition;

    protected CardInfo myCardInfo;

    protected Tuning tuning; // Reference to Tuning object

	//Usability variables: Indices correspond to enums for time and terrain. 0 means not usable 1 means usable.
	int[] terrainUse = new int[4];
	int[] timeUse = new int[4];

	int handPos; // Keep track of what position each card is in player's hand

    void Start()
    {
        tuning = Tuning.tuning;
        player = Player.player;
        UImanager = UIManager.UImanager;
        float scaleFactor = tuning.scaleFactor; // Get scale factor from tuning object
        scaleVector = new Vector3(scaleFactor, scaleFactor); // This vector is added to local scale on Grow()
        clickManager = new ClickManager();
	}

    // This is called in CardGame and overridden in CardObject subclasses (PlayerCardObject and EnemyCardObject)
    public virtual void CreateCard(CardInfo cardInfo)
    {

    }

    /* This function is called in PlayerCardObject and EnemyCardObject
     * Sets info both classes have in common
     * Assigns myCardInfo, cardBackground, titleText, terrainText, cardTypeText, 
     * description, accepted terrains
     */
    protected void SetCommonInfo(CardInfo cardInfo)
    {
        myCardInfo = cardInfo;

        // Set reference to image component(s) in children
        images = GetComponentsInChildren<Image>();
        cardBackground = images[0].sprite; // Setting the background is called in each subclass

        // Set references to Text components in Children
        text = GetComponentsInChildren<Text>();
        titleText = text[0];
        terrainText = text[1];
        cardTypeText = text[2];
        description = text[3];

        // Set array of accepted terrains
        acceptedTerrains = myCardInfo.terrains;

        // Assign strings to Text components
        titleText.text = myCardInfo.title;
        cardTypeText.text = cardInfo.cardType;
        description.text = cardInfo.desc;
        SetTerrainText();
    }

    public void PlayCard()
    {
        CheckOwner();
        owner.PlayCard(this);
        played = true;
        PlayEffect();  
    }

    // Overridden by Discovery Cards, etc.
    public virtual void PlayEffect() {
        // Something here
        // Hide card
		if (myCardInfo.cardType == "Dialogue") {

			if (myCardInfo.title == "Sage Tree Ghost") {
				Fungus.Flowchart.BroadcastFungusMessage ("sagetree");
			} else if (myCardInfo.title == "Merchant Gaspard") {
				Fungus.Flowchart.BroadcastFungusMessage ("gaspard");
			} else if (myCardInfo.title == "Grandpa Bark") {
				Fungus.Flowchart.BroadcastFungusMessage ("grandpa");
			} else if (myCardInfo.title == "Enraged Ragti") {
				Fungus.Flowchart.BroadcastFungusMessage ("ragti");
			} else if (myCardInfo.title == "Abandoned House") {
				Fungus.Flowchart.BroadcastFungusMessage ("house");
			} else if (myCardInfo.title == "Trouble in Trusian Cave") {
				Fungus.Flowchart.BroadcastFungusMessage ("grateria");
			} else {
				Debug.Log ("Card under construction");
			}
		}
		int diceRoll = -1;
		if (myCardInfo.deckType == DeckType.AI) {
			//AI Cards
			if (myCardInfo.title == "Cave") {
				GameController.gameController.MoveTo ("cave");
			} else if (myCardInfo.title == "Swamp") {
				GameController.gameController.MoveTo ("swamp");
			} else if (myCardInfo.title == "Hill") {
				GameController.gameController.MoveTo ("hills");
			} else if (myCardInfo.title == "Forest") {
				GameController.gameController.MoveTo ("forest");
			} else if (myCardInfo.title == "Cynocephali Merchants") {
				diceRoll = Random.Range (0, 2);
				if (diceRoll == 1) {
					player.ChangeStats (-3);
				} else {
					player.SelectedCard = player.GetHand () [Random.Range (0, player.GetHand ().Count)];
					UImanager.Discard.DiscardRand ();
				}
			} else if (myCardInfo.title == "Heavy Rain") {
				diceRoll = Random.Range (0, 2);
				player.ChangeStats (-3);
				player.SelectedCard = player.GetHand () [Random.Range (0, player.GetHand ().Count)];
				UImanager.Discard.DiscardRand ();
			} else if (myCardInfo.title == "Mushroom Poisoning") {
				diceRoll = Random.Range (0, 3);
				if (diceRoll == 1) {
					player.SelectedCard = player.GetHand () [Random.Range (0, player.GetHand ().Count)];
					UImanager.Discard.DiscardRand ();
					player.SelectedCard = player.GetHand () [Random.Range (0, player.GetHand ().Count)];
					UImanager.Discard.DiscardRand ();
				} else {
					player.ChangeStats (-4);
				}
			} else if (myCardInfo.title == "Ravenous Pack of Hounds") {
				player.ChangeStats (-2);
				player.SelectedCard = player.GetHand () [Random.Range (0, player.GetHand ().Count)];
				UImanager.Discard.DiscardRand ();
			} else if (myCardInfo.title == "Snake Bite") {
				diceRoll = Random.Range (0, 3);
				if (diceRoll == 1) {
					player.ChangeStats (-6);
				} else {
					player.ChangeStats (-4);
				}
			} else if (myCardInfo.title == "Swamp Hole") {
				player.ChangeStats (-2);
				GameController.gameController.MoveTo ("swamp");
			} else if (myCardInfo.title == "Bean Nighe") {
				player.ChangeStats (-2);
			} else if (myCardInfo.title == "Alchemy Practice") {
				player.ChangeStats (-4);
				CardGame.Instance.DealCards (1, player.GetDeck (), CardGame.Instance.playerHandTargets, player);
				CardGame.Instance.DealCards (1, player.GetDeck (), CardGame.Instance.playerHandTargets, player);
			} else {
				player.ChangeStats (-1);
			}
		} else {
		//Player Cards
			if (myCardInfo.title == "Esoteric Palmist"||myCardInfo.title == "Pitfall Diagram"||myCardInfo.title == "Glyphs on a Wall"||myCardInfo.title == "Hidden Path"||myCardInfo.title == "Unicorn Hair"||myCardInfo.title == "Old Log Cabin") {
				CardGame.Instance.DealCards (2, player.GetDeck (), CardGame.Instance.playerHandTargets, player);
			} else if (myCardInfo.title == "Naughty Knickers"||myCardInfo.title == "Hieroglyph Book"||myCardInfo.title == "Love Letter"||myCardInfo.title == "Big Metal Key") {
				CardGame.Instance.DealCards (1, player.GetDeck (), CardGame.Instance.playerHandTargets, player);
			}else if (myCardInfo.title == "Polite Kettle"||myCardInfo.title == "Well-Kept House"||myCardInfo.title == "River Treehouse") {
				player.ChangeStats (2);
			} else if (myCardInfo.title == "Everlasting Lantern"||myCardInfo.title == "Tree Temple"||myCardInfo.title == "Magical Plants") {
				player.ChangeStats (1);
			} else if (myCardInfo.title == "Magic Chest"||myCardInfo.title == "Qilin Lake") {
				CardGame.Instance.DealCards (5, player.GetDeck (), CardGame.Instance.playerHandTargets, player);
			} else {
				diceRoll = Random.Range (1,11);
				if(diceRoll==7){
					CardGame.Instance.DealCards (1, player.GetDeck (), CardGame.Instance.playerHandTargets, player);
				}
			}
		}

        gameObject.SetActive(false);
    }

    // Sets Card Background
    // This is called in PlayerCardObject and EnemyCardObject
	public void SetCardBackground(Sprite sprite) {
		images[0].sprite = sprite;
	}

    /*
     * Sets the card's terrain text from its accepted terrains array
     * This is called in SetCommonInfo()
     * 
     * Ex: [Swamp, Forest] will produce the string "Swamp/Forest"
     * If the card accepts every terrain, the terrain text is set to "Any"
     */
    void SetTerrainText()
    {
        if (acceptedTerrains.Length == GameController.gameController.terrains.Length)
        { // If this card accepts the total number of terrains
            terrainText.text = "Any"; // Set its terrain text to "Any"
            return;
        }
        // Combine terrains into one string
        string terrainsString = acceptedTerrains[0].name;
        for (int i = 1; i < acceptedTerrains.Length; i++)
        {
            terrainsString += "/" + acceptedTerrains[i].name;
        }
        terrainText.text = terrainsString;
    }

    // This is called from CardGame when cards are dealt
    public void SetOwner(CardPlayer cardPlayer)
    {
        owner = cardPlayer;
		inHand = true;
		/*if (owner.name == "Enemy") {
			Lock ();
		}*/
    }

    public CardPlayer GetOwner()
    {
        CheckOwner();
        return owner;
    }

    void CheckOwner()
    {
        if (owner == null)
        {
            if (myCardInfo.deckType == DeckType.AI)
            {

                owner = CardGame.Instance.enemy;

            }
            else if (myCardInfo.deckType == DeckType.Player)
            {

                owner = CardGame.Instance.player;

            }
        }
    }

    public CardInfo GetCardInfo()
    {
        return myCardInfo;
    }

    public bool Played
    {
        get { return played; }
    }

    public virtual void OnMouseDown() {
		EventController.Event("DrawCard");

        if (clickManager.DoubleClick())
        {
            Grow();
        }
        // Push to front
        transform.SetAsLastSibling();
    }

    /*void OnMouseUp() {
        Shrink();
    }*/

    public virtual void Grow()
    {
        /*CardObject selectedCard = player.SelectedCard;
        CardObject viewedCard = player.ViewedCard;
        Debug.Log(viewedCard == null);
        if (selectedCard != null && selectedCard != this)
        {
            player.ReturnCardToHand();
        }
        if (viewedCard != null & viewedCard != this)
        {
            player.ReturnViewedCard();
        }*/
        player.CheckSelection(this);
        lastPosition = transform.localPosition;
        EventController.Event("PlayTapToView");
        //Debug.Log(lastPosition);
        transform.localPosition = tuning.largeCardPosition;
        transform.localScale = tuning.largeCardScale;
        hasShrunk = false;
    }

    public virtual void Shrink()
    {
        transform.localPosition = lastPosition;
		transform.localScale = tuning.cardScale;
        EventController.Event("PlayAICardShrink");
		hasShrunk = true;
    }

	// set the position of where the card is in player's hand
	public void SetHandPosition (int n)
	{
		handPos = n;
	}

	// return position of where card is in player's hand
	public int GetHandPosition ()
	{
		return handPos;
	}
}

