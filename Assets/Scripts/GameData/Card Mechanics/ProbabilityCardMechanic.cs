/*
 * Author: Isaiah Mann
 * Description: Probabilitiy of different mechanics occuring
 */

[System.Serializable]
public class ProbabilityCardMechanic : CardMechanic {

	public ProbabilityCardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.Probability, stats, owner) {

	}

	public ProbabilityCardMechanic (MechanicStats stats) : base (MechanicVariant.Probability, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
