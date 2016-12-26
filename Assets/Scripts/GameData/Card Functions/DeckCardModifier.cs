/*
 * Author: Isaiah Mann
 * Description: Modifies the deck
 */

[System.Serializable]
public class DeckCardModifier : CardModifier {

	public DeckCardModifier (CardFunctionType type, LexCard owner) : 
	base (type, CardFunctionVariant.DeckModifier, owner) {

	}

	public DeckCardModifier (CardFunctionType type) : 
	base (type, CardFunctionVariant.DeckModifier) {

	}

	public override void ApplyEffect (GameController game) {

	}
}
