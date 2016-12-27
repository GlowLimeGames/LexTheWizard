/*
 * Author: Isaiah Mann
 * Description: Modifies mana
 */

[System.Serializable]
public class ManaCardMechanic : CardMechanic {

	public ManaCardMechanic (CardMechanicType type, LexCard owner) : 
	base (type, CardMechanicVariant.Mana, owner) {

	}

	public ManaCardMechanic (CardMechanicType type) : 
	base (type, CardMechanicVariant.Mana) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
