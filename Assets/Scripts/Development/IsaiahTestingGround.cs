using UnityEngine;
using System.Collections;

public class IsaiahTestingGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
		testDeckReading();
	}

	void testDeckReading () {
		CardInfo [] playerDeck = CardUtil.ReadPlayerCardInfoFromFile("Decks/PlayerTestDeck");

		Debug.Log(
			ArrayUtil.ToString (
				playerDeck
			)
		);

		CardInfo[] aiDeck = CardUtil.ReadAICardInfoFromFile("Decks/AITestDeck");

		Debug.Log(
			ArrayUtil.ToString(
				aiDeck
			)
		);
	}
}
