/*
 * Author: Isaiah Mann
 * Description: Describes a functionality of a card
 */

using System.Collections;
using System.Collections.Generic;

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
	Probability,
	Conditional,
}

[System.Serializable]
public struct MechanicDelegates {
	const int DEFAULT_VALUE = 0;

	private string[] delegateKeys;
	private Dictionary<string, object> delegates;

	public MechanicDelegates (string[] delegateKeys) {
		this.delegateKeys = delegateKeys;
		delegates = new Dictionary<string, object>();
		foreach (string key in delegateKeys) {
			delegates.Add(key, DEFAULT_VALUE);
		}
	}

	public bool HasDelegate (string key) {
		return ArrayUtil.Contains(delegateKeys, key);
	}

	public T GetDelegate<T> (string delegateKey) {
		try {	
			return (T) delegates[delegateKey];
		} catch {
			return default(T);
		}
	}

	public void SetDelegate<T> (string delegateKey, T value) {
		if (delegates.ContainsKey(delegateKey)) {
			delegates[delegateKey] = value;
		}
	}

	// Values and delegates should map by index
	public void MapDelegates (object[] delegateValues) {
		if (delegateKeys.Length == delegateValues.Length) {
			for (int i = 0; i < delegateKeys.Length; i++) {
				delegates[delegateKeys[i]] = delegateValues[i];
			}
		} else {
			throw new System.ArgumentException(
				string.Format("Key list of size {0} does not match value list of size {1}", delegateKeys.Length, delegateValues.Length));
		}
	}
}

[System.Serializable]
public struct MechanicStats { 
	public string id;
	public MechanicType type;
	private MechanicDelegates delegates;

	public MechanicStats (string id, MechanicType type, string[] delegateKeys) { 
		this.id = id;
		this.type = type;
		delegates = new MechanicDelegates(delegateKeys);
	}

	public bool HasDelegate (string key) {
		return delegates.HasDelegate(key);
	}

	public T GetDelegate<T> (string delegateKey) {
		return delegates.GetDelegate<T>(delegateKey);
	}

	public void SetDelegate<T> (string delegateKey, T value) {
		delegates.SetDelegate(delegateKey, value);
	}

	public void MapDelegates (object[] delegateValues) {
		delegates.MapDelegates(delegateValues);
	}
}

[System.Serializable]
public abstract class CardMechanic : CardData {

	#region Keys 

	protected const string DELAY = "Delay";
	protected const string DURATION = "Duration";
	protected const string AMOUNT = "Amount";
	protected const string SKIPS_TURNS = "SkipsTurns";
	protected const string DISCARDS = "Discards";

	#endregion

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
			return stats.GetDelegate<int>(DELAY);
		}
		set {
			stats.SetDelegate<int>(DELAY, value);
		}
	}
	protected int effectDuration {
		get {
			return stats.GetDelegate<int>(DURATION);
		}
		set {
			stats.SetDelegate<int>(DURATION, value);
		}
	}
	protected int effectAmount {
		get {
			return stats.GetDelegate<int>(AMOUNT);
		}
		set {
			stats.SetDelegate<int>(AMOUNT, value);
		}
	}
	int remainingEffectDelay;
	int remainingEffectDuration;
	public bool hasEffectDelay {
		get {
			return remainingEffectDelay > 0;
		}
	}

	public void MapDelegates (object[] delegateValues) {
		stats.MapDelegates(delegateValues);
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

	public CardMechanic Clone () {
		CardMechanicFactory factory = new CardMechanicFactory();
		return factory.GetMechanic(this.variant, this.stats);
	}

	protected virtual void setup () {
		// NOTHING
	}
}
