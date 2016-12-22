using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Hide", menuName = "UIEvent/Hide", order = 1)]
public class UIHideAction : UIAction {
	public override void Execute (UIElement target){
		target.Hide();	
	}
}
