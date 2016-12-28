/*
 * Author: Isaiah Mann
 * Description: Modifies travel abilities
 */

[System.Serializable]
public class TravelCardMechanic : CardMechanic {

	public TravelCardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.Travel, stats, owner) {

	}

	public TravelCardMechanic (MechanicStats stats) : base (MechanicVariant.Travel, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
