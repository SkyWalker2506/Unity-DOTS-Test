using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
 
    private Dictionary<int, string> CachedNumberStrings = new();
    private int[] _frameRateSamples;
    private int _cacheNumbersAmount = 300;
    private int _averageFromAmount = 30;
    private int _averageCounter = 0;
    private int _currentAveraged;
 
    void Awake()
    {
        Application.targetFrameRate = 500;
        {
            for (int i = 0; i < _cacheNumbersAmount; i++) {
                CachedNumberStrings[i] = i.ToString();
            }
            _frameRateSamples = new int[_averageFromAmount];
        }
    }
    void Update()
    {
        {
            var currentFrame = (int)Mathf.Round(1f / Time.smoothDeltaTime); 
            _frameRateSamples[_averageCounter] = currentFrame;
        }
 
        {
            var average = 0f;
 
            foreach (var frameRate in _frameRateSamples) {
                average += frameRate;
            }
 
            _currentAveraged = (int)Mathf.Round(average / _averageFromAmount);
            _averageCounter = (_averageCounter + 1) % _averageFromAmount;
        }
 
        // Assign to UI
        {
            _text.SetText(_currentAveraged < _cacheNumbersAmount && _currentAveraged > 0
                ? CachedNumberStrings[_currentAveraged]
                : _currentAveraged < 0
                    ? "< 0"
                    : _currentAveraged > _cacheNumbersAmount
                        ? $"> {_cacheNumbersAmount}"
                        : "-1");
        }
    }
}