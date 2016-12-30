/*
 * Author: Isaiah Mann
 * Description: Represents a deck of cards
 */

using System;
using System.Linq;
using System.Collections.Generic;

public class Deck : LTWData {
	List<Card> cards;

	public Deck (Card[] cards) {
		this.cards = new List<Card>(cards);
	}

	public Card Draw () {
		Card top = this.cards.FirstOrDefault();
		this.cards.Remove(top);
		return top;
	}

	public Card Pick (string cardName) {
		Card select = this.cards.Find(c => c.Name.Equals(cardName));
		this.cards.Remove(select);
		return select;
	}

	public void Add (Card card) {
		this.cards.Add(card);
	}

	public void Shuffle () {
		// Source: http://stackoverflow.com/questions/273313/randomize-a-listt
		cards.OrderBy(a => Guid.NewGuid());
	}
}
