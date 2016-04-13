using UnityEngine;
using System.Collections;

public class DeselectCard : MonoBehaviour {

	void OnMouseDown() {
		//Debug.Log ("Deselecting");
		Player.player.ReturnCard ();
		UIManager.UImanager.ShowActionIcons (false);
	}
}
