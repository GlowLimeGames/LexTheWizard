/*
 * Author: Isaiah Mann
 * Description: creates dialogues
 */

[System.Serializable]
public class DialogueCardMechanic : CardMechanic {

	public DialogueCardMechanic (MechanicStats stats, LexCard owner) :
	base (MechanicVariant.Dialogue, stats, owner) {

	}

	public DialogueCardMechanic (MechanicStats stats) : base (MechanicVariant.Dialogue, stats) {

	}

	public override bool ApplyEffect (GameController game) {
		if (base.ApplyEffect(game)) {
			return true;
		} else {
			return false;
		}
	}
}
