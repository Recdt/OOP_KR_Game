using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RabbitLogic : Animal
{
    [SerializeField, Range(50,100)]private float hunger = 75f;
    private float _maxHunger;
    [SerializeField, Range(2,5)] private float speed = 2f;
    [SerializeField, Range(10, 40)] private float nutritionalValue = 10;
    private List<Transform> _victim;
    private List<Transform> _wolfs;
    [SerializeField] private Wandering wandering;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
