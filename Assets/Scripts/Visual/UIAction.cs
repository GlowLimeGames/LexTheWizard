using UnityEngine;

public class UIAction : ScriptableObject {
	public virtual void Execute (UIElement target){
		Debug.LogFormat("Executing UI action on {0}", target);
	}
}
	