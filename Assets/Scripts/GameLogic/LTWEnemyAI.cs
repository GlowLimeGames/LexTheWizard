/*
 * Author: Isaiah Mann
 * Description: Represents an enemy AI
 */

public class LTWEnemyAI : LTWAgent {
	public LTWEnemyAI (GameController game, Deck deck) : base (game, deck, new LTWAgentStats(AgentType.AI)) {}
}
