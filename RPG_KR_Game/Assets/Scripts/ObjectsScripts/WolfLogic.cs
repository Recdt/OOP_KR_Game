using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class WolfLogic : MonoBehaviour, IDying, IStarving, ITrigger,ICollision
{
    #region Properties
    
    [SerializeField, Range(100,200)]
    private float hunger = 100f;
    [SerializeField, Range(3,7)] 
    private float speed = 5f;
    private float nutritionalValue = 20;

    private List<Transform> _victim;
    private List<Transform> _wolfs;
    private Wandering _wandering;
    private float _maxHunger;

    #endregion
    #region Methouds
    
    public void Starving()
    {
        hunger -= Time.deltaTime;
    }

    public void Dying()
    {
        if (hunger <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
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
        IsTargetFound();
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Wolfs")
        {
            _wolfs.Remove(other.gameObject.transform);
            IsTargetFound();
        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Victim")
        {
            _victim.Remove(other.gameObject.transform);
            IsTargetFound();
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (LayerMask.LayerToName(col.gameObject.layer) == "Victim")
        {
            _victim.Remove(col.gameObject.transform);
            Destroy(col.gameObject);
            hunger += nutritionalValue;
            IsTargetFound();
        }
        else if (LayerMask.LayerToName(col.gameObject.layer) == "Wolfs" &&
                 hunger >= 0.5f * _maxHunger)
        {
            //create wolf and -hunger
            Instantiate(gameObject, transform.position, Quaternion.identity);
            hunger -= 3*nutritionalValue/2;
            _wolfs.Remove(col.gameObject.transform);
            IsTargetFound();
        }
        else if (LayerMask.LayerToName(col.gameObject.layer) == "Water")
        {
            Destroy(gameObject);
        }
    }
    private void IsTargetFound()
    {
        if (!_victim.Any() || (!_wolfs.Any() && hunger>=0.5*_maxHunger)) _wandering.enabled = true;
        else _wandering.enabled = false;
    }
    private void LifeCycle()
    {
        if (hunger <= 0.5 * _maxHunger)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                _victim.First().transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                _wolfs.First().transform.position, speed * Time.deltaTime);
        }
    }
    #endregion
    #region StartAndUpdate
    void Start()
    {
        hunger = 100;
        _maxHunger = hunger;
        speed = Random.Range(2, 6);
        _victim = new List<Transform>();
        _wolfs = new List<Transform>();
        hunger = Random.Range(35, 49);
        _wandering = GetComponent<Wandering>();
    }
    void Update()
    {
        Starving();
        Dying();
        LifeCycle();
    }
    #endregion
}
