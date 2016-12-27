using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Fungus;

public class GameController : MonoBehaviour {

    public static GameController instance;
    
	private int currentState = 0;
	private bool salvageAllowedAtNight = false;

    [SerializeField]
    private MonoBehaviour[] gameStates;

	private List<CardMechanic> currentCardMechanics = new List<CardMechanic>();
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
        Morning,
        Afternoon,
        Night
    }

	// Uses a backing var to broadcast an event whenever value is changed
	// Var must be set to night to start (so that it increments to dawn for the first phase)
	DayTime _currentDayTime = DayTime.Night;
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
        if (instance == null)
        {
            instance = this;
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
    /// Sets isNextState to true to let the GameController know to move onto the next state during the LateUpdate
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

	public void AddCard (Card card) {
		CardDatabase.AddCard(card);
	}

	public Card DrawAICard () {
		return CardDatabase.DrawAI();
	}

	public Card DrawPlayerCard () {
		return CardDatabase.DrawPlayer();
	}

	public void AddCurrentCardMechanic (CardMechanic mechanic) {
		currentCardMechanics.Add(mechanic);
	}

	public void RemoveCurrentCardMechanic (CardMechanic mechanic) {
		currentCardMechanics.Remove(mechanic);
	}

	public void TickDownCurrentMechanics () {
		foreach (CardMechanic mechanic in currentCardMechanics) {
			if (mechanic.hasEffectDelay) {
				mechanic.TickDownEffectDelay();
			}
		}
	}
		
	public void ApplyCardEffects () {
		for (int i = 0; i < currentCardMechanics.Count; i++) {
			CardMechanic mechanic = currentCardMechanics[i];
			if (mechanic.hasEffectDelay) {
				continue;
			} else {
				mechanic.ApplyEffect(this);
				// Active mechanics can ony be used once before they're discarded
				if (mechanic.type == CardMechanicType.Active) {
					RemoveCurrentCardMechanic(mechanic);
				}
			}
		}
	}

	// Currently ignores card index but may be relevant in future
	public bool CanSalvage (int cardIndex) {
		return currentDayTime != DayTime.Night || salvageAllowedAtNight;
	}

	public void AllowSalvageAtNight () {
		salvageAllowedAtNight = true;
	}
}
