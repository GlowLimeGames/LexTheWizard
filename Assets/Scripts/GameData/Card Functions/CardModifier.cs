/*
 * Author: Isaiah Mann
 * Description: Describes a functionality of a card
 */


public enum CardFunctionType {
	Active,
	Passive,
}

public enum CardFunctionVariant {
	BurnModifier,
	DecayModifier,
	ManaModifier,
	PointModifier,
	AIModifier,
	DeckModifier,
	TravelModifier,
}

[System.Serializable]
public abstract class CardModifier : CardData {
	public string id;
	public CardFunctionType type {get; private set;}
	public CardFunctionVariant variant {get; private set;}
	// Measured in day phases:
	public int effectDelay;
	public bool hasEffectDelay {
		get {
			return effectDelay > 0;
		}
	}

	public CardModifier (CardFunctionType type, CardFunctionVariant variant, LexCard owner) : base (owner) {
		Setup(type, variant);
	}

	public CardModifier (CardFunctionType type, CardFunctionVariant variant) {
		Setup(type, variant);
	}

	protected void Setup (CardFunctionType type, CardFunctionVariant variant) {
		this.type = type;
		this.variant = variant;
	}

	public abstract void ApplyEffect (GameController game);
}
