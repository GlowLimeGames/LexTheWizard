
[System.Serializable]
public class LTWAgent {
	public AgentType Type {
		get {
			return stats.Type;
		}
	}
	public bool ShouldSkipTurn {
		get {
			return turnsToSkip > 0;
		}
	}
		
	protected LTWAgentStats stats;
	protected int turnsToSkip = 0;
	protected GameController game;

	public LTWAgent (GameController game, LTWAgentStats stats) {
		this.game = game;
		this.stats = stats;
	}

	public void SkipTurn (int numTurns = 1) {
		this.turnsToSkip += numTurns;
	}

	public bool TryTakeTurn () {
		if (ShouldSkipTurn) {
			handleTurnSkipped();
			return false;
		} else {
			takeTurn();
			return true;
		}
	}

	public Card Discard () {
		throw new System.NotImplementedException();
	}

	protected virtual void takeTurn () {
		// NOTHING
	}

	protected void handleTurnSkipped () {
		turnsToSkip--;
	}
}

[System.Serializable]
public class LTWAgentStats : LTWData {
	public AgentType Type;

	public LTWAgentStats (AgentType type) {
		this.Type = type;
	}
}