/*
 * Author: Isaiah Mann
 * Description: Represents an enemy AI
 */

public class LTWEnemyAI : LTWAgent {
	public LTWEnemyAI (GameController game) : base (game, new LTWAgentStats(AgentType.AI)) {}
}
