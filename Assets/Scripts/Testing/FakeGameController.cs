using UnityEngine;
using System.Collections;

public class FakeGameController : GameController {
	// Keeps these methods from running in the superclass:
	void Start(){
		SalvageCardMechanic salvageMechanic = new SalvageCardMechanic(Card.ACTIVE, new LexCard());
		AddCurrentCardMechanic(salvageMechanic);
	}
	void LateUpdate(){}


}
