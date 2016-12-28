/*
 * Author: Isaiah Mann
 * Description: Modifies Discard / Burning cards
 */

[System.Serializable]
public class SalvageCardMechanic : CardMechanic {
	public bool allowsSalvageAtNight;

	public SalvageCardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.Salvage, stats, owner) {

	}

	public SalvageCardMechanic (MechanicStats stats) : base (MechanicVariant.Salvage, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			if (allowsSalvageAtNight) {
				game.AllowSalvageAtNight();
			}
			return true;
		} else {
			return false;
		}
	}
}
