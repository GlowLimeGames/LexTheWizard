/*
 * Author: Isaiah Mann
 * Description: Modifies points
 */

[System.Serializable]
public class PointCardModifier : CardModifier {

	public PointCardModifier (CardFunctionType type, LexCard owner) : 
	base (type, CardFunctionVariant.PointModifier, owner) {

	}

	public PointCardModifier (CardFunctionType type) : 
	base (type, CardFunctionVariant.PointModifier) {

	}

	public override void ApplyEffect (GameController game) {
		
	}
}
