using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Behavior;
using Unity.VisualScripting;

public class BunnyLogic:Animal,ICollision,ITrigger
{
    #region Properties
    private readonly List<Flee> _flees = new List<Flee>();
    
    #endregion
    
    #region Methouds
    public void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        var flee = gameObject.AddComponent<Flee>();
        flee.objectToFlee = other.gameObject.transform;
        flee.ChangeWeight(10);
        _flees.Add(flee);
    }

    public void OnTriggerExit2D(UnityEngine.Collider2D other)
    {
        var flee = _flees.Find(x => x.objectToFlee == other.gameObject.transform);
        _flees.Remove(flee);
        Destroy(flee);
    }
    public void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) != "Water") return;
        Destroy(gameObject);
    }
    
    #endregion
}
