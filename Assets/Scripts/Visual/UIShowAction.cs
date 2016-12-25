using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Show", menuName = "UIEvent/Show", order = 0)]
public class UIShowAction : UIAction {
	public override void Execute (UIElement target){
		target.Show();
	}
}
