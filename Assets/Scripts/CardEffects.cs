using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CardEffects : MonoBehaviour {

    /// <summary>
    /// Changes the number of points that the player has by i
    /// </summary>
    /// <param name="i">How many points are given, negative numbers subtract points</param>
	public void ChangePoints(int i){
        GameController.INSTANCE.Points += i;
	}

    /// <summary>
    /// Should be called from the flowchart whenever the dialog finishes
    /// Makes the canvas active again
    /// </summary>
    public void ToggleCanvas(bool isOn)
    {
        GameController.INSTANCE.canvas.SetActive(isOn);
    }
}
