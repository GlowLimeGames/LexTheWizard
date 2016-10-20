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
        GameController.INSTANCE.Points += i;
		Debug.Log ("Changed points by " + i);
	}

    public void StartDialog(Fungus.Flowchart flowchart)
    {
        GameController.INSTANCE.canvas.SetActive(false);
        Instantiate(flowchart);
    }
}
