/*
 * Author: Isaiah Mann
 * Description: Modifies AI Behaviour / Abilities
 */

[System.Serializable]
public class AICardModifier : CardModifier {

	public AICardModifier (CardFunctionType type, LexCard owner) : 
	base (type, CardFunctionVariant.AIModifier, owner) {

	}

	public AICardModifier (CardFunctionType type) : 
	base (type, CardFunctionVariant.AIModifier) {

	}

	public override void ApplyEffect (GameController game) {
		
	}
}
