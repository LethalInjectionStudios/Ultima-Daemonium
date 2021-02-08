using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Torch : MonoBehaviour
{
    private Light2D _torchlight;
    private float _minIntensity = .5f;
    private float _maxIntensity = 1.5f;
    [SerializeField] private float _targetIntensity = 1;
    [SerializeField] private bool _directionSwitcher = false;
    [SerializeField] private float _currentIntensity;
    private int _flickerMultiplier = 5;

    private void Awake()
    {
        _torchlight = GetComponentInChildren<Light2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
