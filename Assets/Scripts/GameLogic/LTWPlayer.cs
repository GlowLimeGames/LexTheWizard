/*
 * Author: Isaiah Mann
 * Description: Represents a player
 */

public class LTWPlayer : LTWAgent {
	public LTWPlayer (GameController game, Deck deck) : base (game, deck, new LTWAgentStats(AgentType.Player)) {}
}
