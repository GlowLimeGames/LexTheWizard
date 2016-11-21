using UnityEngine;
using System.Collections.Generic;
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
public class LexCard {
    [XmlElement("CardName")]
    public string CardName;

    [XmlElement("CardText")]
    public string CardText;

    [XmlElement("CardImage")]
    public string CardImageName;

    [XmlElement("Terrain")]
    public string Terrain;

    [XmlElement("DayPhase")]
    public string DayPhase;

    [XmlElement("Week")]
    public int Week;

    [XmlElement("Flowchart")]
    public string Flowchart;
}

[XmlRoot("CardCollection")]
public class CardCollection {

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
public class CardParsing {
	
	public const string PlayerXML = "Cards/Cards_Player";
    public const string AIXML = "Cards/Cards_AI";
	public const string BlankCard = "Cards/BlankCard";
	public const string ArtPath = "Cards";
	public const string PrefabFolder = "Assets/Resources/CardPrefabs";

	// [MenuItem("Cards/Reset Card Collection")]
	public static void ResetCardList () {
        CardCollection aiCards = CardCollection.Load(AIXML);
        CardCollection playerCards = CardCollection.Load(PlayerXML);

        foreach (LexCard lexCard in aiCards.Cards) {
            CardDatabase.AddCard(lexCard, true);
        }

        foreach (LexCard lexCard in playerCards.Cards) {
            CardDatabase.AddCard(lexCard, false);
        }
	}
}