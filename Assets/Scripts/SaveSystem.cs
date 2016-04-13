/*
 *Static class to save and load data from any class
 */

using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveSystem {
	public static SaveData saveGame;

	public static void Save () {
		saveGame = GameController.gameController.saveData;
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/saveGame.gd");
		//Debug.Log (Application.persistentDataPath + "/saveGame.gd");
		bf.Serialize (file, saveGame);
		file.Close();
	}

	public static void Load(){
		if(File.Exists(Application.persistentDataPath + "/saveGame.gd")){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + "/saveGame.gd", FileMode.Open);
			saveGame = (SaveData)bf.Deserialize (file);
			file.Close ();
		}
	}
}
