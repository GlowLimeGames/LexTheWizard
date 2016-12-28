/*
 * Author: Isaiah Mann
 * Description: Modifies mana
 */

[System.Serializable]
public class ManaCardMechanic : CardMechanic {

	public ManaCardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.Mana, stats, owner) {

	}

	public ManaCardMechanic (MechanicStats stats) : base (MechanicVariant.Mana, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
