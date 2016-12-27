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

[XmlRoot("CardCollection")]
public class CardCollection {
	[XmlArray("PlayerCards")]
	[XmlArrayItem("Card")]
	public List<Card> PlayerCards = new List<Card>();

    [XmlArray("AICards")]
    [XmlArrayItem("Card")]
    public List<Card> AICards = new List<Card>();

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
    public const string XMLPath = "Cards/Cards";

	public static void ResetCardList () {
        CardCollection cards = CardCollection.Load(XMLPath);

        foreach (Card card in cards.AICards) {
			CardDatabase.AddCard(new Card(card, LexCard.Type.AI));
        }

        foreach (Card card in cards.PlayerCards) {
			CardDatabase.AddCard(new Card(card, LexCard.Type.PLAYER));
        }
	}
}