using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEditor.SceneTemplate;
using UnityEditor.VersionControl;
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

    public void eventInvoker(List<GameObject> plants)
    {
        onPlantListUpdate?.Invoke(plants);
    }

}