using UnityEngine;
using System.Collections;

public class ButtonAudio : MonoBehaviour {

    public void playDiscardSFX()
    {
        EventController.Event("PlayDiscard");
    }

    public void playDiscoveryCardSFX()
    {
        EventController.Event("PlayDiscoveryCard");
    }
    public void playDrawCardSFX()
    {
        EventController.Event("DrawCard");
    }
}
