/*
 * Author: Isaiah Mann
 * Description: Represents a player
 */

public class LTWPlayer : LTWAgent {
	public LTWPlayer (GameController game) : base (game, new LTWAgentStats(AgentType.Player)) {}
}
