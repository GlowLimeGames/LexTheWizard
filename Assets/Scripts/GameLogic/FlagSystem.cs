using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlagSystem : MonoBehaviour {

    public static FlagSystem INSTANCE;

    private Dictionary<string, object> flags = new Dictionary<string, object>();

    void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

    }

    public bool DoesFlagExist(string flagName)
    {
        return flags.ContainsKey(flagName);
    }

    public void RemoveFlag(string flagName)
    {
        flags.Remove(flagName);
    }

    public void AddFlag(string flagName, object flagInfo = null)
    {
        flags.Add(flagName, flagInfo);
    }

    public object GetFlagInfo(string flagName)
    {
        object flagInfo;
        flags.TryGetValue(flagName, out flagInfo);
        return flagInfo;
    }

}
