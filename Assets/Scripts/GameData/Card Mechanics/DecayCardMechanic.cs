/*
 * Author: Isaiah Mann
 * Description: Adds card decay
 */

[System.Serializable]
public class DecayCardMechanic : CardMechanic {
	
	public DecayCardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.Decay, stats, owner) {

	}

	public DecayCardMechanic (MechanicStats stats) : base (MechanicVariant.Decay, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
