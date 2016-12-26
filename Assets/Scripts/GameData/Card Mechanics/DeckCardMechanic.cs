/*
 * Author: Isaiah Mann
 * Description: Modifies the deck
 */

[System.Serializable]
public class DeckCardMechanic : CardMechanic {

	public DeckCardMechanic (CardMechanicType type, LexCard owner) : 
	base (type, CardMechanicVariant.Deck, owner) {

	}

	public DeckCardMechanic (CardMechanicType type) : 
	base (type, CardMechanicVariant.Deck) {

	}

	public override void ApplyEffect (GameController game) {

	}
}
