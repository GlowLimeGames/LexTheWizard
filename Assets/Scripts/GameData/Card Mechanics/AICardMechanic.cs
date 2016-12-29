/*
 * Author: Isaiah Mann
 * Description: Modifies AI Behaviour / Abilities
 */

[System.Serializable]
public class AICardMechanic : CardMechanic {
	bool skipsAITurn = false;
	int turnSkipAmount = 1;

	public AICardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.AI, stats, owner) {
		setup();
	}

	public AICardMechanic (MechanicStats stats) : base (MechanicVariant.AI, stats) {
		setup();
	}

	protected override void setup () {
		base.setup();
		if (stats.HasDelegate(SKIPS_TURNS)) {
			skipsAITurn = stats.GetDelegate<bool>(SKIPS_TURNS);
		}
		if (skipsAITurn && stats.HasDelegate(AMOUNT)) {
			turnSkipAmount = stats.GetDelegate<int>(AMOUNT);
		}
	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			if (skipsAITurn) {
				game.SkipTurn(AgentType.AI, turnSkipAmount);
			}
			return true;
		} else {
			return false;
		}
	}
}
