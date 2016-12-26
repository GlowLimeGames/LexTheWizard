/*
 * Author: Isaiah Mann
 * Description: Modifies travel abilities
 */

[System.Serializable]
public class TravelCardModifier : CardModifier {

	public TravelCardModifier (CardFunctionType type, LexCard owner) : 
	base (type, CardFunctionVariant.TravelModifier, owner) {

	}

	public TravelCardModifier (CardFunctionType type) : 
	base (type, CardFunctionVariant.TravelModifier) {

	}

	public override void ApplyEffect (GameController game) {

	}
}
