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
	
	public const string PlayerXML = "Cards/Cards_Player";
    public const string AIXML = "Cards/Cards_AI";
	public const string BlankCard = "Cards/BlankCard";
	public const string ArtPath = "Cards";
	public const string PrefabFolder = "Assets/Resources/CardPrefabs";

	[MenuItem("Cards/Reset Card Collection")]
	static void ResetCardList () {
        CardCollection aiCards = CardCollection.Load(AIXML);
        CardCollection playerCards = CardCollection.Load(PlayerXML);

        foreach (LexCard lexCard in aiCards.Cards) {
            CardDatabase.AddCard(lexCard, true);
        }

        foreach (LexCard lexCard in playerCards.Cards) {
            CardDatabase.AddCard(lexCard, false);
        }

        /*
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
        buildCollection(tempList, PlayerXML, false);
        buildCollection(tempList, AIXML, true);
        */
	}

    /*
    private static void buildCollection (CardDatabase database, string path, bool ai) {
        CardCollection collection = CardCollection.Load(path);
        foreach (LexCard lexCard in collection.Cards) {
            GameObject go = Resources.Load(BlankCard) as GameObject;
            go.name = lexCard.CardName;

            Sprite cardImage = Resources.Load<Sprite>(ArtPath + lexCard.CardImageName);
            if (cardImage)
                go.transform.FindChild("Card Image").GetComponent<Image>().sprite = cardImage;
            go.transform.FindChild("Card Name").GetComponent<Text>().text = lexCard.CardName;
            go.transform.FindChild("Card Text").GetComponent<Text>().text = lexCard.CardText;

            Object empty = PrefabUtility.CreateEmptyPrefab(PrefabFolder + "/" + lexCard.CardName + ".prefab");
            GameObject prefab = PrefabUtility.ReplacePrefab(go, empty);
            Card card = prefab.GetComponent<Card>();
            card.Init(lexCard);
            card.Type = ai ? Card.CardType.AI : Card.CardType.Player;
            database.CardList.Add(prefab);
        }
    }
    */

    /*
	[MenuItem("Cards/Test Card Effect")]
	static void TestCardEvents(){
		CardEffects toTest = GameObject.FindGameObjectWithTag ("Card").GetComponent<CardEffects> ();
		if (toTest)
			toTest.OnPlay ();
	}
    */
}