/*
 * Author: Isaiah Mann
 * Description: Modifies the deck
 */

// NOTES: Should probably be able to target either player or AI: makes it more flexible
[System.Serializable]
public class DeckCardMechanic : CardMechanic {

	public DeckCardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.Deck, stats, owner) {

	}

	public DeckCardMechanic (MechanicStats stats) : base (MechanicVariant.Deck, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
