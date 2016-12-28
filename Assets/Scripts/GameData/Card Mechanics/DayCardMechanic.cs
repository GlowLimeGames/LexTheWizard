/*
 * Author: Isaiah Mann
 * Description: Modifies day phases
 */

[System.Serializable]
public class DayCardMechanic : CardMechanic {

	public DayCardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.Day, stats, owner) {

	}

	public DayCardMechanic (MechanicStats stats) : base (MechanicVariant.Day, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
