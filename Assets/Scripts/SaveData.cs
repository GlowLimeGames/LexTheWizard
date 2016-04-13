using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData {

	public List<string> playerHand;
	public List<string> playerDeck;
	public List<string>  enemyHand;
	public List<string> enemyDeck;
	public int score;
	public int phase;
	public int days;
	public string currDayTime;
	public string currTerrain;
	public int currTerrainIndex;
}
