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

	public override void ApplyEffect (GameController game) {

	}
}
