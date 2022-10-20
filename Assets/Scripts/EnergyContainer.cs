using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyContainer : MonoBehaviour
{
    public int energyCount;
    [SerializeField] TextMeshProUGUI _energyTxt;
    public static EnergyContainer instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        energyCount = 0;
        _energyTxt.text = energyCount.ToString();
    }
    public void AddEnergy()
    {
        energyCount += 25;
        _energyTxt.text = energyCount.ToString();
    }
    public void SpentEnergy(int _energyNeed)
    {
        energyCount -= _energyNeed;
        _energyTxt.text = energyCount.ToString();
    }
}
