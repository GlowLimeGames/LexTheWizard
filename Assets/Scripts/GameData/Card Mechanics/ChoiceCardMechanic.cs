/*
 * Author: Isaiah Mann
 * Description: Modifies AI Behaviour / Abilities
 */

[System.Serializable]
public class ChoiceCardMechanic : CardMechanic {

	public ChoiceCardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.AI, stats, owner) {

	}

	public ChoiceCardMechanic (MechanicStats stats) : base (MechanicVariant.AI, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
