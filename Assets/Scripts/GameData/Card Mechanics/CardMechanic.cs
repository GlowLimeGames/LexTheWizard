/*
 * Author: Isaiah Mann
 * Description: Describes a functionality of a card
 */


public enum CardMechanicType {
	Active,
	Passive,
}

public enum CardMechanicVariant {
	Salvage,
	Decay,
	Mana,
	Point,
	AI,
	Deck,
	Travel,
}

[System.Serializable]
public abstract class CardMechanic : CardData {
	public string id;
	public CardMechanicType type {get; private set;}
	public CardMechanicVariant variant {get; private set;}
	// Measured in day phas es:
	public int effectDelay;
	int remainingEffectDelay;
	public bool hasEffectDelay {
		get {
			return remainingEffectDelay > 0;
		}
	}

	public CardMechanic (CardMechanicType type, CardMechanicVariant variant, LexCard owner) : base (owner) {
		Setup(type, variant);
	}

	public CardMechanic (CardMechanicType type, CardMechanicVariant variant) {
		Setup(type, variant);
	}

	protected void Setup (CardMechanicType type, CardMechanicVariant variant) {
		this.type = type;
		this.variant = variant;
		remainingEffectDelay = effectDelay;
	}

	public void TickDownEffectDelay () {
		if (remainingEffectDelay > 0) {
			remainingEffectDelay--;
		}
	}
	public abstract void ApplyEffect (GameController game);
}
