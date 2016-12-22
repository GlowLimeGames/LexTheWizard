using UnityEngine;

[CreateAssetMenuAttribute(fileName = "RandomSprite", menuName = "UIEvent/RandomSprite", order = 2)]
public class UIRandomSpriteAction : UIAction {
	public override void Execute (UIElement target){
		target.RandomSprite();
	}
}
