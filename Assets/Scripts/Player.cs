using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : CardPlayer {
	
	public static Player player; // Static instance of this class
	
	// Stat variables
	int points;
	
	// Card Player variables
	CardObject selectedCard;
	
	void Awake() {
		player = this;
		base.Awake ();
	}
	
	void Start() {
		base.Start ();
		cardPlayerName = "Lex";
	}
	
	// This allows other objects to get stats from Player without reassigning them
	public int[] GetStats()
	{
		return new int[1] {points};
	}
	
	public void ChangeStats(int pointsChange)
	{
		points += pointsChange;
		UImanager.SetStats(points);
	}
	
	public override void PlayCard(CardObject cardObject) {
		selectedCard = cardObject;
		UImanager.ShowConfirmMenu(true);
	}
	
	public void Confirm(bool isConfirmed) {
		if (isConfirmed) {
			CardInfo playedCardInfo = selectedCard.GetCardInfo();
			string cardName = playedCardInfo.title;
			RemoveCardFromHand(selectedCard);
			
			int pointsChange = playedCardInfo.points;
			
			if (pointsChange > 0) {
				EventController.Event("PointIncrease");
			}
			
			ChangeStats(pointsChange);
			gameController.Turn ();
			
			Debug.Log("Lex just played" + cardName);
		}
		else {
			Debug.Log("Lex cancelled");
		}
		selectedCard = null;
	}
}