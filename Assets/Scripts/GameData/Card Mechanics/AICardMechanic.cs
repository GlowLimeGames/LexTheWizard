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

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
