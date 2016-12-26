/*
 * Author: Isaiah Mann
 * Description: Modifies Discard / Burning cards
 */

[System.Serializable]
public class BurnCardModifier : CardModifier {
	public bool allowsBurningAtNight;

	public BurnCardModifier (CardFunctionType type, LexCard owner) : 
	base (type, CardFunctionVariant.BurnModifier, owner) {

	}

	public BurnCardModifier (CardFunctionType type) : 
	base (type, CardFunctionVariant.BurnModifier) {

	}

	public override void ApplyEffect (GameController game) {

	}
}
