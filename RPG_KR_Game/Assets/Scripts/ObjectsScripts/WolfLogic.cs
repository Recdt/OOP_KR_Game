using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Behavior;
using UnityEngine.SceneManagement;

public class WolfLogic : Animal, IDying, IStarving, ICollision, ITrigger
{
    #region Properties
    [SerializeField] private float lifeTime = 120f;
    [SerializeField] private float eatTime = 45f;
    private List<Seek> _seeks;
    private Coroutine _destroying;
    #endregion
    
    #region Methouds
    private void Awake()
    {
        _seeks = new List<Seek>();
    }
    
    public void Starving()
    {
        lifeTime -= Time.deltaTime;
    }

    public void Dying()
    {
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Water" || LayerMask.LayerToName(other.gameObject.layer) == "Wolfs" ) return;
        var seek = gameObject.AddComponent<Seek>();
        seek.objectToFollow = other.gameObject.transform;
        seek.ChangeWeight(3);
        _seeks.Add(seek);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        var seek = _seeks.Find(x => x.objectToFollow == other.gameObject.transform);
        _seeks.Remove(seek);
        Destroy(seek);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Rabbits" || LayerMask.LayerToName(other.gameObject.layer) == "Mooses")
        {
            Destroy(other.gameObject);
            lifeTime += eatTime;
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("UI");
        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Water")
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        Starving();
        Dying();
    }
    #endregion
}
