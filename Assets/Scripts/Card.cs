using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour{

    public Fungus.Flowchart cardEffectsOnPlay;

    public void OnPlay()
    {
        if(cardEffectsOnPlay != null)
        {
            Instantiate(cardEffectsOnPlay);
        }
    } 
}