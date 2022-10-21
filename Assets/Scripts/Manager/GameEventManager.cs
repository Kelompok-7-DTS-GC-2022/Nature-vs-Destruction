using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager
{
    private static GameEventManager instance = null;
    public static GameEventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEventManager();
            }
            return instance;
        }
    }

    public event Action<List<GameObject>> onPlantListUpdate;
    // public event Action<int, GameObject> onPlantListUpdate;

    public void plantUpdateEventInvoker(List<GameObject> plants)
    {
        onPlantListUpdate?.Invoke(plants);
    }

}