using UnityEngine;
using System.Collections;
public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventController.Event("PlayMenuMusic");
	}
}
