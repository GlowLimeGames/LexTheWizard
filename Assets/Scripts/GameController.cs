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

    public Flowchart flowchart;

    [SerializeField]
    private GameObject canvas;

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

    public void StartDialogue(string name)
    {
        canvas.SetActive(false);

        flowchart.SendFungusMessage(name);
    }

}
