using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardDatabase : MonoBehaviour {
	public List<Object> CardList;

    private static List<GameObject> AICardPool = new List<GameObject>();
    private static List<GameObject> PlayerCardPool = new List<GameObject>();
    private static List<GameObject> PlayerDeck = new List<GameObject>();
    private static List<GameObject> AIDeck = new List<GameObject>();

    public CardDatabase() {
		CardList = new List<Object> ();
    }

    void Start () {
        foreach (Object o in CardList){
            GameObject card = (GameObject)o;
            if (card.GetComponent<Card>().isAI()) {
                AICardPool.Add(card);
            } else {
                PlayerCardPool.Add(card);
            }
        }
        UpdateDecks();
    }

    private static GameObject Draw(List<GameObject> deck, bool onlyPlayable = false) {
        int index;
        GameObject card = null;
        if (deck.Count == 0) {
            print("Out of cards!");
        }
        else if (onlyPlayable) {
            List<GameObject> subDeck = new List<GameObject>();
            foreach (GameObject c in deck) {
                if (c.GetComponent<Card>().isCurrentlyPlayable()) {
                    subDeck.Add(c);
                }
            }
            card = Draw(subDeck);
        }
        else {
            index = Random.Range(0, deck.Count);
            card = deck[index];
            deck.Remove(card);
        }
        return card;
    }

    public static GameObject DrawPlayer() { return Draw(PlayerDeck); }
    public static GameObject DrawAI() { return Draw(AIDeck, true); }

    private static void UpdateDeck(List<GameObject> deck, List<GameObject> cardPool) {
        List<GameObject> remove = new List<GameObject>();
        foreach (GameObject card in cardPool) {
            if (card.GetComponent<Card>().isInPlay()) {
                deck.Add(card);
                remove.Add(card);
            }
        }
        foreach (GameObject card in remove) {
            cardPool.Remove(card);
        }
    }

    public static void UpdateDecks() {
        UpdateDeck(AIDeck, AICardPool);
        UpdateDeck(PlayerDeck, PlayerCardPool);
    }
}