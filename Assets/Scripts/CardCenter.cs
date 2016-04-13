/*
 * This is attached to a child of CardObject
 * Contains a smaller BoxCollider2D located about the center of the card
 * 
 * Used to register collisions with DiscardPiles
 */
using UnityEngine;
using System.Collections;

public class CardCenter : MonoBehaviour {
	/*
	CardObject cardObject; // Reference to this CardCenter's CardObject

	void Start() {
		cardObject = transform.parent.GetComponent<CardObject> ();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		GameObject colObject = coll.gameObject;
		if (colObject.tag == "Discard")
		{
			cardObject.Shrink();
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		GameObject colObject = coll.gameObject;
		if (colObject.tag == "Discard")
		{
			cardObject.Grow();
		}
	}*/
}
