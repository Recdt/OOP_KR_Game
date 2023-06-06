using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WolfLogic : Animal
{
    [SerializeField, Range(100,200)]private float hunger = 100f;
    private float _maxHunger;
    [SerializeField, Range(3,7)] private float speed = 3f;
    [SerializeField, Range(10, 40)] private float nutritionalValue = 10;
    private List<Transform> _victim;
    private List<Transform> _wolfs;
    [SerializeField] private Wandering wandering;
    
    void Start()
    {
        hunger = Random.Range(100, 200);
        _maxHunger = hunger;
        speed = Random.Range(1, 5);
        _victim = new List<Transform>();
        _wolfs = new List<Transform>();
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (LayerMask.LayerToName(col.gameObject.layer) == "Wolfs")
        {
            var target = col.GetComponent<Transform>();
            _wolfs.Add(target);
        }
        else if (LayerMask.LayerToName(col.gameObject.layer) == "Victim")
        {
            var target = col.GetComponent<Transform>();
            _victim.Add(target);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Wolfs") _wolfs.Remove(other.gameObject.transform);
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Victim") _victim.Remove(other.gameObject.transform);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (LayerMask.LayerToName(col.gameObject.layer) == "Victim")
        {
            _victim.Remove(col.gameObject.transform);
            Destroy(col.gameObject);
            hunger += nutritionalValue;
        }
        else if (LayerMask.LayerToName(col.gameObject.layer) == "Wolfes" &&
                 hunger >= 0.5f * _maxHunger)
        {
            //create wolf and -hunger
        }
        else if (LayerMask.LayerToName(col.gameObject.layer) == "Water")
        {
            Destroy(gameObject);
        }
    }

    private void LifeCycle()
    {
        if (hunger <= 0.5 * _maxHunger) transform.position = Vector2.MoveTowards(transform.position,
            _victim.First().position, speed * Time.deltaTime);
        else transform.position = Vector2.MoveTowards(transform.position, 
            _wolfs.First().position, speed * Time.deltaTime);
    }

    private void IsTargetFound()
    {
        if (_victim.Count == 0 && _wolfs.Count == 0) wandering.enabled = false;
        else wandering.enabled = true;
    }
    void Update()
    {
        Starving(hunger);
        Dying(hunger);
    }
}
