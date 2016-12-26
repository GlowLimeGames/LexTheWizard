/*
 * Author: Isaiah Mann
 * Description: Modifies mana
 */

[System.Serializable]
public class ManaCardModifier : CardModifier {

	public ManaCardModifier (CardFunctionType type, LexCard owner) : 
	base (type, CardFunctionVariant.ManaModifier, owner) {

	}

	public ManaCardModifier (CardFunctionType type) : 
	base (type, CardFunctionVariant.ManaModifier) {

	}

	public override void ApplyEffect (GameController game) {

	}
}
