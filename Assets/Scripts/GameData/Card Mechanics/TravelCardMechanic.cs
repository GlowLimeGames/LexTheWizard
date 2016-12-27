/*
 * Author: Isaiah Mann
 * Description: Modifies travel abilities
 */

[System.Serializable]
public class TravelCardMechanic : CardMechanic {

	public TravelCardMechanic (CardMechanicType type, LexCard owner) : 
	base (type, CardMechanicVariant.Travel, owner) {

	}

	public TravelCardMechanic (CardMechanicType type) : 
	base (type, CardMechanicVariant.Travel) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
