using UnityEngine;
using System.Collections;

public interface ICardBehavior {
	//Specifies what appens when a card is played
	//Parameters passed are to be added to player stats. The last one is a string so check != "" for no change else add the item to inventory.
	void action (int pointsChange,int salvageChange, int goldChange, string inventoryChange);
	//Returns whether or not the character in question can play the card.
	bool isPlayable ();
}
