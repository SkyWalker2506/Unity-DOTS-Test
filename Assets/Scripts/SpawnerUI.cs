using System;
using TMPro;
using UnityEngine;

public class SpawnerUI : MonoBehaviour
{
    public static Action OnSpawn;
    public static Action<int> OnBatchChanged;
    [SerializeField] private TMP_Text _batchText;

    public void OnSpawnButton()
    {
        OnSpawn?.Invoke();   
    }
    
    public void OnBatchSlider(float value)
    {
        int _batchCount = (int)value;
        OnBatchChanged?.Invoke(_batchCount);
        _batchText.SetText("Batch Count " + _batchCount);
    }
}
