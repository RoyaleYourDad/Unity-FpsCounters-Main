// FPSCounter8TextMexhPro.cs
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(TMP_Text))]
public class FPSCounter8TextMeshPro : MonoBehaviour
{
    private struct AverageFloat
    {
        public float Average => _value / _count;

        private float _value;
        private int _count;

        public void Add(float number)
        {
            _value += number;
            _count++;
        }

        public void Reset()
        {
            _value = 0f;
            _count = 0;
        }
    }

    [SerializeField] private float _averageValueCollectionTime = 2f;
    [SerializeField] private float _refreshFrequency = 0.4f;

    private float _timeSinceFpsReset = 0f;
    private float _timeSinceUpdate = 0f;
    private AverageFloat _fpsValue;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (_timeSinceFpsReset > _averageValueCollectionTime)
        {
            _timeSinceFpsReset = 0;
            _fpsValue.Reset();
        }

        _fpsValue.Add(1f / Time.unscaledDeltaTime);
        _timeSinceFpsReset += Time.deltaTime;

        if (_timeSinceUpdate < _refreshFrequency)
        {
            _timeSinceUpdate += Time.deltaTime;
            return;
        }

        int fps = Mathf.RoundToInt(_fpsValue.Average);
        _text.text = fps.ToString();

        _timeSinceUpdate = 0f;
    }
}