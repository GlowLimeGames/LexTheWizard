using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController INSTANCE;
    private int currentState = 0;

    [SerializeField]
    private MonoBehaviour[] gameStates;

    private bool isNextState = false;

    public enum Terrain
    {
        Swamps,
        Hills,
        Forrests,
        Caves
    }

    public Terrain currentTerrain = Terrain.Swamps;

    public int dayCount = 0;

    public enum DayTime
    {
        Dawn,
        Dusk,
        Night
    }

    public DayTime currentDayTime = DayTime.Dawn;

    private int mana;

    public int Mana
    {
        get
        {
            return mana;
        }
        set
        {
            mana = value;
            manaText.text = "Mana: " + mana;
        }
    }

    private int points;

    public int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
            pointsText.text = "Points: " + points;
        }
    }

    // UI stuff to be replaced////////////////////
    public Text manaText;
    public Text pointsText;
    public Text eventText;
    ////////////////////////////////

    private Card card1;
    private Card card2;
    private Card card3;
    
    public Card Card1
    {
        get
        {
            return card1;
        }
        set
        {
            card1 = value;
            updateCards();
        }
    }

    public Card Card2
    {
        get
        {
            return card2;
        }
        set
        {
            card2 = value;
            updateCards();
        }
    }

    public Card Card3
    {
        get
        {
            return card3;
        }
        set
        {
            card3 = value;
            updateCards();
        }
    }

    void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        
    }

    void Start()
    {
        gameStates[0].enabled = true;
        Points = 0;
        Mana = 0;

    }

    void Update()
    {

    }

    /// <summary>
    /// Sets isNextState to true to let the GameController know to move onto the next state durring the LateUpdate
    /// </summary>
    public void NextState()
    {
        isNextState = true;
    }

    void LateUpdate()
    {
        if (isNextState)
        {
            gameStates[currentState].enabled = false;
            currentState++;
            currentState = currentState % gameStates.Length;
            gameStates[currentState].enabled = true;
            isNextState = false;
        }
    }

    public void updateCards()
    {
        eventText.text = "";

        if(card1 != null)
        {
            eventText.text += "Card1: " + Card1.Name + " " + Card1.Description + "\n";
        }

        if (card2 != null)
        {
            eventText.text += "Card2: " + Card2.Name + " " + Card2.Description + "\n";
        }

        if (card3 != null)
        {
            eventText.text += "Card3: " + Card3.Name + " " + Card3.Description + "\n";
        }
    }

}
