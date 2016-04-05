using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData {

	//public List<CardObject> playerHand;
	public List<CardInfo> playerDeck;
	//public List<CardObject>  enemyHand;
	public List<CardInfo> enemyDeck;
	public int score;
	public int phase;
	public int days;
	public string currDayTime;
	public string currTerrain;
	public int currTerrainIndex;
}
