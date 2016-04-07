using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCardObject : CardObject {

    public override void CreateCard(CardInfo cardInfo)
    {
        SetCommonInfo(cardInfo); // Function from parent class

        SetCardBackground(acceptedTerrains[0].enemyCardArt);
    }

    public override void OnMouseDown()
    {
        if (clickManager.DoubleClick())
        {
            player.ViewedCard = this;
            Grow();
            // Push to front
            transform.SetAsLastSibling();
            UImanager.ShowActionIcons(false);
        }
    }
}
