using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Behavior;

public class WolfLogic : Animal, IDying, IStarving
{
    #region Properties
    [SerializeField] private float lifeTime = 120f;
    [SerializeField] private float eatTime = 45f;
    private List<Seek> _seeks;
    private Coroutine _destroying;
    #endregion
    
    #region Methouds
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    #endregion
}
