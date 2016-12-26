/*
 * Author: Isaiah Mann
 * Description: Modifies Discard / Burning cards
 */

[System.Serializable]
public class SalvageCardMechanic : CardMechanic {
	public bool allowsSalvageAtNight;

	public SalvageCardMechanic (CardMechanicType type, LexCard owner) : 
	base (type, CardMechanicVariant.Salvage, owner) {

	}

	public SalvageCardMechanic (CardMechanicType type) : 
	base (type, CardMechanicVariant.Salvage) {

	}

	public override void ApplyEffect (GameController game) {
		if (allowsSalvageAtNight) {
			game.AllowSalvageAtNight();
		}
	}
}
