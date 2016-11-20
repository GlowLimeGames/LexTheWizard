using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
/// <summary>
/// This script governs the reading of the XML document into cards for customization. It parses the xml information to generate a list of cards, 
/// then searches through the prefab folder indicated below for prefabs with the right names. It creates any that it needs to, updates any cards whose names are still there,
/// and deletes any whose names are no longer in the system.
/// 
/// TODO: 	Make the paths customizable outside the script editor.
/// 		Establish an undo pattern.
/// 		Further parse the cards into their respective decks.
/// </summary>
/// 
/*
public class LexCard {
    [XmlElement("CardName")]
    public string CardName;

    [XmlElement("CardText")]
    public string CardText;

    [XmlElement("CardImage")]
    public string CardImageName;

    public LexCard() { }
}
*/

[XmlRoot("CardCollection")]
public class CardCollection{

	[XmlArray("Cards")]
	[XmlArrayItem("Card")]
	public List<LexCard> Cards = new List<LexCard>();

	public static CardCollection Load(string path){
		TextAsset _xml = Resources.Load<TextAsset> (path);
		XmlSerializer serializer = new XmlSerializer (typeof(CardCollection));
		StringReader reader = new StringReader (_xml.text);

		CardCollection cards = serializer.Deserialize (reader) as CardCollection;
		reader.Close();
		return cards;
	}
}
/// <summary>
/// Utility class responsible for parsing the XML document, generating a list of cards, and cleaning up the card prefab folder.
/// </summary>
public class CardParsing{
	
	public const string XMLDoc = "Cards/Cards";
	public const string BlankCard = "Cards/BlankCard";
	public const string ArtPath = "Cards";
	public const string PrefabFolder = "Assets/Resources/CardPrefabs";

	[MenuItem("Cards/Reset Card Collection")]
	static void ResetCardList ()
	{
        Object cardDatabase = null;

		foreach (Object obj in Resources.LoadAll("CardPrefabs")) {
			// Debug.Log (AssetDatabase.GetAssetPath (obj));
            if (obj.name != "CardDatabase") {
                AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(obj));
            }
            else {
                cardDatabase = obj;
            }
        }

        GameObject tempListGO = new GameObject();
        if (cardDatabase == null) {
            cardDatabase = PrefabUtility.CreateEmptyPrefab(PrefabFolder + "/CardDatabase.prefab");
        }
        GameObject tempPrefab = PrefabUtility.ReplacePrefab(tempListGO, cardDatabase);
        MonoBehaviour.DestroyImmediate(tempListGO);
        CardDatabase tempList = tempPrefab.AddComponent<CardDatabase>();

        CardCollection collection = CardCollection.Load (XMLDoc);
		foreach (LexCard card in collection.Cards) {
			GameObject go = Resources.Load (BlankCard) as GameObject;
			go.name = card.CardName;
            
			Sprite cardImage = Resources.Load<Sprite> (ArtPath + card.CardImageName);
			if (cardImage)
				go.transform.FindChild ("Card Image").GetComponent<Image> ().sprite = cardImage;
			go.transform.FindChild ("Card Name").GetComponent<Text> ().text = card.CardName;
			go.transform.FindChild ("Card Text").GetComponent<Text> ().text = card.CardText;
            
			Object empty = PrefabUtility.CreateEmptyPrefab (PrefabFolder+ "/" + card.CardName + ".prefab");
            GameObject prefab = PrefabUtility.ReplacePrefab(go, empty);
            prefab.GetComponent<Card>().Init(card);
			tempList.CardList.Add (prefab);
		}
	}

    /*
	[MenuItem("Cards/Test Card Effect")]
	static void TestCardEvents(){
		CardEffects toTest = GameObject.FindGameObjectWithTag ("Card").GetComponent<CardEffects> ();
		if (toTest)
			toTest.OnPlay ();
	}
    */
}