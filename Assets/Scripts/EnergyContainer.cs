using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyContainer : MonoBehaviour
{
    public int energyCount = 20000;
    [SerializeField] TextMeshProUGUI _energyTxt;
    public static EnergyContainer instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        energyCount = 20000;
        _energyTxt.text = energyCount.ToString();
    }
    public void AddEnergy()
    {
        energyCount += 25;
        _energyTxt.text = energyCount.ToString();
    }
    public void SpentEnergy(int _energyNeed)
    {
        if (energyCount > _energyNeed)
        {
            energyCount -= _energyNeed;
            _energyTxt.text = energyCount.ToString();
        }
    }
}
