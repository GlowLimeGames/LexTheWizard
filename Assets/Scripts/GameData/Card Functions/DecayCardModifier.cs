/*
 * Author: Isaiah Mann
 * Description: Adds card decay
 */

[System.Serializable]
public class DecayCardModifier : CardModifier {

	public DecayCardModifier (CardFunctionType type, LexCard owner) : 
	base (type, CardFunctionVariant.DecayModifier, owner) {

	}

	public DecayCardModifier (CardFunctionType type) : 
	base (type, CardFunctionVariant.DecayModifier) {

	}

	public override void ApplyEffect (GameController game) {

	}
}
