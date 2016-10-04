using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AIPlayState : MonoBehaviour{

    void Update()
    {
        GameController.INSTANCE.NextState();
    }

}
