using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCardObject : CardObject {

    Text goldText;
    Text pointsText;
    Text salvageText;
    Sprite art;

    public override void CreateCard(CardInfo cardInfo)
    {
        SetCommonInfo(cardInfo); // Function from parent class

        SetCardBackground(acceptedTerrains[0].playerCardArt);
        images[1].sprite = cardInfo.art; // Images array is assigned in parent class

        // Set references to remaining Text components
        goldText = text[4];
        pointsText = text[5];
        salvageText = text[6];

        // Assign strings to Text components
        goldText.text = cardInfo.gold.ToString();
        pointsText.text = cardInfo.points.ToString();
        salvageText.text = cardInfo.salvage.ToString();

        // Add Click and Drag functionality to this object
        gameObject.AddComponent<ClickAndDrag>();
    }
}
