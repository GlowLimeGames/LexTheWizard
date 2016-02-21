using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

    public void LoadSceneOnClick(int level)
    {
        Application.LoadLevel(level);
    }
}
