using UnityEngine;
using System.Collections;
using SimpleJSON;

public class FakeGameController : GameController {
	public TextAsset mechanicsJSON;

	// Keeps these methods from running in the superclass:
	void Start(){
		CardMechanicFactory factory = new CardMechanicFactory();
		JSONNode json = JSON.Parse(mechanicsJSON.text);
		JSONArray arr = json["Mechanics"].AsArray;
		CardMechanic[] mechanics = new CardMechanic[arr.Count];
		for (int i = 0; i < arr.Count; i++) {
			mechanics[i] = factory.GetMechanic(arr[i].ToString());
		}
	}

	void LateUpdate(){}
}
