/*
 * Author: Isaiah Mann
 * Description: Probabilitiy of different mechanics occuring
 */

[System.Serializable]
public class ConditionalCardMechanic : CardMechanic {

	public ConditionalCardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.Conditional, stats, owner) {

	}

	public ConditionalCardMechanic (MechanicStats stats) : base (MechanicVariant.Conditional, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
