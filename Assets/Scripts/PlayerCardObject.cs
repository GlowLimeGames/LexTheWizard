using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCardObject : CardObject {

	public GameObject card;
	public GameObject iconObject;

    Text goldText;
    Text pointsText;
    Text salvageText;
    Sprite art;
	Sprite icon;

    public override void CreateCard(CardInfo cardInfo)
    {
        SetCommonInfo(cardInfo); // Function from parent class

        SetCardBackground(acceptedTerrains[0].playerCardArt);
        images[1].sprite = cardInfo.art; // Images array is assigned in parent class
		images[2].sprite = GameController.gameController.thisCardGame.GetIconByType(cardInfo.cardType);

        // Set references to remaining Text components
        goldText = text[4];
        pointsText = text[5];
        salvageText = text[6];

        // Assign strings to Text components
        goldText.text = cardInfo.gold.ToString();
        pointsText.text = cardInfo.points.ToString();
        salvageText.text = cardInfo.salvage.ToString();

		toggleIcon (true);

        // Add Click and Drag functionality to this object
        //gameObject.AddComponent<ClickAndDrag>();
    }

    public override void OnMouseDown()
    {
        if (clickManager.DoubleClick())
        {
			toggleIcon(false);
            showActionMenu();
        }
    }

	public override void Shrink() {
		base.Shrink ();
		toggleIcon (true);
	}

    void showActionMenu()
    {
        transform.SetAsLastSibling();
        Grow();
        Player.player.SelectedCard = this;
        UImanager.ShowActionIcons(true);
    }

	void toggleIcon(bool showIcon) {
		Debug.Log ("toggling Icon on? " + showIcon.ToString ());
		iconObject.SetActive (showIcon);
		card.SetActive (! showIcon);
		images [0].enabled = ! showIcon;
	}
}