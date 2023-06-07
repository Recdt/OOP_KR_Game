using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RabbitLogic : MonoBehaviour, IDying, IStarving, ITrigger,ICollision
{
    #region Properties
    
    [SerializeField, Range(50,100)]
    private float hunger = 750f;
    [SerializeField, Range(3,7)] 
    private float speed = 5f;
    [SerializeField, Range(10, 40)] 
    private float nutritionalValue = 10;
    [SerializeField] 
    private GameObject prefab;
    
    private List<Transform> _grass;
    private List<Transform> _rabbits;
    private List<Transform> _wolfs;
    private Wandering _wandering;
    private float _maxHunger;
    private bool _isRunningAway;
    
    #endregion
    #region Methouds
    
    public void Starving()
    {
        hunger -= 2*Time.deltaTime;
    }
    public void Dying()
    {
        if (hunger <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D col)//дописати втечу зайця від вовка
    {
        if (LayerMask.LayerToName(col.gameObject.layer) == "Wolfs")
        {
            var target = col.GetComponent<Transform>();
            _wolfs.Add(target);
            _isRunningAway = true;
        }
        else if (LayerMask.LayerToName(col.gameObject.layer) == "Grass")
        {
            var target = col.GetComponent<Transform>();
            _grass.Add(target);
        }
        else if (LayerMask.LayerToName(col.gameObject.layer) == "Victim")
        {
            var target = col.GetComponent<Transform>();
            _rabbits.Add(target);
        }
        IsTargetFound();
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Wolfs")
        {//дописати параметри погоні
            _wolfs.Remove(other.gameObject.transform);
            if (_wolfs.Count == 0) _isRunningAway = false;
        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Victim") _rabbits.Remove(other.gameObject.transform);
        else if(LayerMask.LayerToName(other.gameObject.layer) == "Grass") _grass.Remove(other.gameObject.transform);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (LayerMask.LayerToName(col.gameObject.layer) == "Grass")
        {
            _grass.Remove(col.gameObject.transform);
            Destroy(col.gameObject);
            hunger += nutritionalValue;
            IsTargetFound();
        }
        else if (LayerMask.LayerToName(col.gameObject.layer) == "Victim" &&
                 hunger >= 0.5f * _maxHunger)
        {
            //create rabbit and -hunger
            Instantiate(prefab, transform.position, Quaternion.identity);
            hunger -= 3*nutritionalValue;
            _rabbits.Remove(col.gameObject.transform);
            IsTargetFound();
        }
        else if (LayerMask.LayerToName(col.gameObject.layer) == "Water" ||
                 LayerMask.LayerToName(col.gameObject.layer) == "Wolf")
        {
            Destroy(gameObject);
        }
    }
    private void LifeCycle()
    {
        if (_isRunningAway)
        {
            RunAway();
        }
        else if (hunger <= 0.5 * _maxHunger)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                _grass.First().transform.position, speed * Time.deltaTime);
        }
        else if(hunger > 0.5 * _maxHunger)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                _rabbits.First().transform.position, speed * Time.deltaTime);
        }
    }
    private void IsTargetFound()
    {
        if (_grass.Count() <= 0 && _wolfs.Count() <= 0 && (_rabbits.Count()<=0 && hunger>=50)) _wandering.enabled = true;
        else _wandering.enabled = false;
    }

    private Vector3 EscapePathVector()
    {
        Vector3 temporary = Vector3.zero;
        foreach (var wolf in _wolfs)
        {
            temporary += (transform.position - wolf.transform.position).normalized;
        }
        return temporary;
    }
    private void RunAway()
    {
        transform.position += EscapePathVector() * speed * Time.deltaTime;
    }
    
    #endregion
    #region StartAndUpdate
    void Start()
    {
        hunger = Random.Range(100, 200);
        _maxHunger = hunger;
        speed = Random.Range(3, 7);
        _grass = new List<Transform>();
        _wolfs = new List<Transform>();
        _rabbits = new List<Transform>();
        hunger = 20;
        _isRunningAway = false;
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
