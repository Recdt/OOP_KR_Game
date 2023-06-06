using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Animal : MonoBehaviour,IDying,IStarving
{
    #region Properties
    private float hunger;
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
    
    #endregion
}
