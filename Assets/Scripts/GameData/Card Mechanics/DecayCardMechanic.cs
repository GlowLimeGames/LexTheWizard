/*
 * Author: Isaiah Mann
 * Description: Adds card decay
 */

[System.Serializable]
public class DecayCardMechanic : CardMechanic {

	public DecayCardMechanic (CardMechanicType type, LexCard owner) : 
	base (type, CardMechanicVariant.Decay, owner) {

	}

	public DecayCardMechanic (CardMechanicType type) : 
	base (type, CardMechanicVariant.Decay) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
