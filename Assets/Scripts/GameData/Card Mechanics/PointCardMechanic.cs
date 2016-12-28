/*
 * Author: Isaiah Mann
 * Description: Modifies points
 */

[System.Serializable]
public class PointCardMechanic : CardMechanic {

	public PointCardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.Point, stats, owner) {

	}

	public PointCardMechanic (MechanicStats stats) : base (MechanicVariant.Point, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
