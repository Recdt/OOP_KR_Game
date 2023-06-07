using System.Collections.Generic;
using System.Linq;
using Interfaces;
using ObjectsScripts;
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

<<<<<<< HEAD
    private List<Transform> _victim;
=======
    private AnimalPlantMediator _md;
    private List<GameObject> _grass;
>>>>>>> main
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
<<<<<<< HEAD
            var target = col.GetComponent<Transform>();
            _victim.Add(target);
=======
            _grass.Add(col.gameObject);
>>>>>>> main
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
        {
            _wolfs.Remove(other.gameObject.transform);
            if (!_wolfs.Any()) _isRunningAway = false;
        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Victim") _rabbits.Remove(other.gameObject.transform);
<<<<<<< HEAD
        else if(LayerMask.LayerToName(other.gameObject.layer) == "Grass") _victim.Remove(other.gameObject.transform);
=======
        else if(LayerMask.LayerToName(other.gameObject.layer) == "Grass") _grass.Remove(other.gameObject);
>>>>>>> main
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
<<<<<<< HEAD
        if (LayerMask.LayerToName(col.gameObject.layer) == "Grass")
        {
            hunger += nutritionalValue;
            _victim.Remove(col.gameObject.transform);
            IsTargetFound();
        }
        else if (LayerMask.LayerToName(col.gameObject.layer) == "Victim" &&
                 hunger >= 0.5f * _maxHunger)
=======
        if (LayerMask.LayerToName(col.gameObject.layer) == "Victim" &&
            hunger >= 0.5f * _maxHunger)
>>>>>>> main
        {
            //create rabbit and -hunger
            Instantiate(gameObject, transform.position, Quaternion.identity);
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
<<<<<<< HEAD
                _victim.First().transform.position, speed * Time.deltaTime);
        }
=======
                _grass.First().transform.position, speed * Time.deltaTime);
            if (transform.position == _grass.First().transform.position) Eat();
            }
>>>>>>> main
        else 
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                _rabbits.First().transform.position, speed * Time.deltaTime);
        }
    }
    private void IsTargetFound()
    {
        if (!_victim.Any() && !_wolfs.Any() && (!_rabbits.Any()|| (_rabbits.Any() && hunger<50))) _wandering.enabled = true;
        else _wandering.enabled = false;
    }

    private void Eat()
    {
        hunger += nutritionalValue;
        _md.Notify(gameObject, _grass.First(), "was eaten");
        _grass.Remove(_grass.First());
        IsTargetFound();
    }

    private Vector3 EscapePathVector()
    {
        Vector3 temporary = Vector3.zero;
        foreach (var wolf in _wolfs)
        {
            temporary += (transform.position - wolf.position).normalized;
        }
        return temporary.normalized;
    }
    private void RunAway()
    {
        transform.position += EscapePathVector()* speed * Time.deltaTime;
    }
    
    #endregion
    #region StartAndUpdate
    void Start()
    {
        hunger = 100;
        _maxHunger = hunger;
        speed = Random.Range(3, 7);
<<<<<<< HEAD
        _victim = new List<Transform>();
=======
        _md = new AnimalPlantMediator();
        _grass = new List<GameObject>();
>>>>>>> main
        _wolfs = new List<Transform>();
        _rabbits = new List<Transform>();
        hunger = Random.Range(35, 49);
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
