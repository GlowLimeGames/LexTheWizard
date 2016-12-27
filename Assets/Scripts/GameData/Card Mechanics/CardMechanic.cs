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
	// Measured in day phases:
	public int effectDelay = 0;
	public int effectDuration = 1;
	int remainingEffectDelay;
	int remainingEffectDuration;
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

	public virtual bool ApplyEffect (GameController game) {
		if (!CanUse()) {
			return false;
		} else {
			if (type == CardMechanicType.Active) {
				remainingEffectDuration--;
			}
			return true;
		}
	}

	public virtual bool CanUse () {
		if (type == CardMechanicType.Active && remainingEffectDuration > 0) {
			return true;
		} else if (type == CardMechanicType.Passive) {
			return true;
		} else {
			return false;
		}
			
	}
}
