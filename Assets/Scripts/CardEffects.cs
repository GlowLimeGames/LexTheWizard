using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CardEffects : MonoBehaviour {
	[SerializeField]
	private UnityEvent effects = null;

	public void OnPlay(){
		effects.Invoke ();
	}

	public void ChangePoints(int i){
		Debug.Log ("Changed points by " + i);
	}
}
