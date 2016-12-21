using UnityEngine;
using System.Collections;

public class UIAction : ScriptableObject {
	public virtual void Execute (UIElement target){
		Debug.LogFormat("Executing UI action on {0}", target);
	}
}


[CreateAssetMenuAttribute(fileName = "Show", menuName = "UIEvent/Show", order = 0)]
public class UIShowAction : UIAction {
	public override void Execute (UIElement target){
		target.Show();
	}
}


[CreateAssetMenuAttribute(fileName = "Hide", menuName = "UIEvent/Hide", order = 1)]
public class UIHideAction : UIAction {
	public override void Execute (UIElement target){
		target.Hide();	
	}
}


[CreateAssetMenuAttribute(fileName = "RandomSprite", menuName = "UIEvent/RandomSprite", order = 2)]
public class UIRandomSpriteAction : UIAction {
	public override void Execute (UIElement target){
		target.RandomSprite();
	}
}
