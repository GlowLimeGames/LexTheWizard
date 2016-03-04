using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCardObject : CardObject {

    public override void CreateCard(CardInfo cardInfo)
    {
        SetCommonInfo(cardInfo); // Function from parent class

        SetCardBackground(acceptedTerrains[0].enemyCardArt);
    }
}
