/*
 * Author: Isaiah Mann
 * Description: Data relating to cards 
 */

[System.Serializable]
public abstract class CardData : LTWData {
	[System.NonSerialized]
	public LexCard owner = null;
	public bool HasOwner {
		get {
			return owner != null;
		}
	}

	public CardData (LexCard owner) {
		this.owner = owner;
	}

	public CardData () {
		this.owner = null;
	}
}
