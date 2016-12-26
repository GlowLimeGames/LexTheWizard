/*
 * Author: Isaiah Mann
 * Description: Modifies AI Behaviour / Abilities
 */

[System.Serializable]
public class AICardMechanic : CardMechanic {

	public AICardMechanic (CardMechanicType type, LexCard owner) : 
	base (type, CardMechanicVariant.AI, owner) {

	}

	public AICardMechanic (CardMechanicType type) : 
	base (type, CardMechanicVariant.AI) {

	}

	public override void ApplyEffect (GameController game) {
		
	}
}
