using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Animal : MonoBehaviour,IDying,IStarving
{
    #region Properties
    
    #endregion
    
    #region Methouds
    
    public void Starving(float Hunger)
    {
        Hunger -= Time.deltaTime;
    }

    public void Dying(float Hunger)
    {
        if (Hunger <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    #endregion
}
