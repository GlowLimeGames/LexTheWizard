using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Fungus;

public class GameController : MonoBehaviour {

    public static GameController INSTANCE;
    private int currentState = 0;

    [SerializeField]
    private MonoBehaviour[] gameStates;

    private bool isNextState = false;

    public GameObject canvas;

    public enum Terrain
    {
        Swamps,
        Hills,
        Forests,
        Caves
    }

	// Uses a backing var to broadcast an event whenever value is changed
	Terrain _currentTerrain = Terrain.Swamps;
	public Terrain currentTerrain {
		get {
			return _currentTerrain;
		}
		set {
			_currentTerrain = value;
			EventController.Event(Event.TERRAIN_CHANGE);
		}
	}

    public int dayCount = 0;

    public int week {
        get {
            return (dayCount + 2) / 3;
        }
    }

    public enum DayTime
    {
        Dawn,
        Dusk,
        Night
    }

	// Uses a backing var to broadcast an event whenever value is changed
	DayTime _currentDayTime = DayTime.Dawn;
	public DayTime currentDayTime {
		get {
			return _currentDayTime;
		}
		set {
			_currentDayTime = value;
			EventController.Event(Event.TIME_OF_DAY_CHANGE);
		}
	}

    private int mana;

    public int Mana
    {
        get
        {
            return mana;
        }
        set
        {
            mana = Mathf.Max(value, 0);
            manaText.text = "" + mana;
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
            points = Mathf.Max(value, 0);
            pointsText.text = "" + points;
        }
    }


    public Hand hand;

    // UI stuff to be replaced////////////////////
    public Text manaText;
    public Text pointsText;
    ////////////////////////////////

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
        CardParsing.ResetCardList();
        gameStates[0].enabled = true;
        Points = 0;
        Mana = 0;
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



}
