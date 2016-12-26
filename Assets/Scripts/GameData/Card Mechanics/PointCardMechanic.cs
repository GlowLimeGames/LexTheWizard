/*
 * Author: Isaiah Mann
 * Description: Modifies points
 */

[System.Serializable]
public class PointCardMechanic : CardMechanic {

	public PointCardMechanic (CardMechanicType type, LexCard owner) : 
	base (type, CardMechanicVariant.Point, owner) {

	}

	public PointCardMechanic (CardMechanicType type) : 
	base (type, CardMechanicVariant.Point) {

	}

	public override void ApplyEffect (GameController game) {
		
	}
}
