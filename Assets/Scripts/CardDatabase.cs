using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardDatabase : MonoBehaviour {
	public List<Object> CardList;

    public Hand hand;
    public AudioClip drawCardSound;

    private static List<GameObject> AICardPool = new List<GameObject>();
    private static List<GameObject> PlayerCardPool = new List<GameObject>();
    private static List<GameObject> PlayerDeck = new List<GameObject>();
    private static List<GameObject> AIDeck = new List<GameObject>();

    public CardDatabase() {
		CardList = new List<Object> ();
    }
    
    void Update() {
        hand.Draw();
        SoundManager.instance.PlaySingle(drawCardSound);
        GameController.INSTANCE.NextState();
    }

    public void Init () {
        foreach (Object o in CardList){
            GameObject card = (GameObject)o;
            if (card.GetComponent<LexCard>().isAI()) {
                AICardPool.Add(card);
            } else {
                PlayerCardPool.Add(card);
            }
        }
        UpdateDecks();
    }

    private static GameObject Draw(List<GameObject> deck, bool onlyPlayable = false) {
        int index;
        GameObject card;
        if (onlyPlayable)
        {
            List<GameObject> subDeck = new List<GameObject>();
            foreach (GameObject c in deck)
            {
                if (c.GetComponent<LexCard>().isCurrentlyPlayable())
                {
                    subDeck.Add(c);
                }
            }
            index = Random.Range(0, subDeck.Count);
            card = subDeck[index];
        }
        else {
            index = Random.Range(0, deck.Count);
            card = deck[index];
        }
        deck.Remove(card);
        return card;
    }

    public static GameObject DrawPlayer() { return Draw(PlayerDeck); }
    public static GameObject DrawAI() { return Draw(AIDeck, true); }

    private static void UpdateDeck(List<GameObject> deck, List<GameObject> cardPool) {
        foreach (GameObject card in cardPool) {
            if (card.GetComponent<LexCard>().isInPlay()) {
                deck.Add(card);
                cardPool.Remove(card);
            }
        }
    }

    public static void UpdateDecks() {
        UpdateDeck(AIDeck, AICardPool);
        UpdateDeck(PlayerDeck, PlayerCardPool);
    }
}
