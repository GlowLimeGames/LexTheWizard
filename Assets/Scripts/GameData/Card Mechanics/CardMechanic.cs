/*
 * Author: Isaiah Mann
 * Description: Describes a functionality of a card
 */


public enum MechanicType {
	Active,
	Passive,
}

public enum MechanicVariant {
	Salvage,
	Decay,
	Mana,
	Point,
	AI,
	Deck,
	Travel,
	Day,
	Dialogue,
	Choice,
}

[System.Serializable]
public struct MechanicStats { 
	public string id;
	public MechanicType type;
	public int effectDelay;
	public int effectDuration;
	public int effectPower;
	public string[] delegates;

	public MechanicStats (string id, MechanicType type, int delay, int duration, int power, string[] delegates) { 
		this.id = id;
		this.type = type;
		this.effectDelay = delay;
		this.effectDuration = duration;
		this.effectPower = power;
		this.delegates = delegates;
	}
}

[System.Serializable]public abstract class CardMechanic : CardData {
	protected MechanicStats stats;
	public string id {
		get {
			return stats.id;
		}
		protected set {
			stats.id = value;
		}
	}
	public MechanicVariant variant {get; private set;}
	public MechanicType type {
		get {
			return stats.type;
		}
		protected set {
			stats.type = value;
		}
	}
	protected int effectDelay {
		get {
			return stats.effectDelay;
		}
		set {
			stats.effectDelay = value;
		}
	}
	protected int effectDuration {
		get {
			return stats.effectDuration;
		}
		set {
			stats.effectDuration = value;
		}
	}
	protected int effectPower = 1;
	int remainingEffectDelay;
	int remainingEffectDuration;
	public bool hasEffectDelay {
		get {
			return remainingEffectDelay > 0;
		}
	}

	public CardMechanic (MechanicVariant variant,
		MechanicStats stats, LexCard owner) : base (owner) {
		this.variant = variant;
		this.stats = stats;
	}

	public CardMechanic (MechanicVariant variant,
		MechanicStats stats) {
		this.stats = stats;
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
			if (type == MechanicType.Active) {
				remainingEffectDuration--;
			}
			return true;
		}
	}

	public virtual bool CanUse () {
		if (type == MechanicType.Active && remainingEffectDuration > 0) {
			return true;
		} else if (type == MechanicType.Passive) {
			return true;
		} else {
			return false;
		}
			
	}
}
