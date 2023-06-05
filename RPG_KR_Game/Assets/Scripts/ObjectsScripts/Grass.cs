using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces.MapInterfaces;
using Unity.VisualScripting;
using Vector3 = System.Numerics.Vector3;

namespace ObjectsScripts
{
    public class Grass : MonoBehaviour, MapObjInterface
    {
        private MapObject _objInfo;

        void Start ()
        {

        }

        void Update()
        {
            
        }

        Vector3 getPosition()
        {

            return _objInfo.getPosition();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Grass was eaten");
            disappear();
        }

        public void growUp()
        {
            
        }
        
        public void growOld()
        {
            
        }
        
        public void disappear()
        {
            Destroy(this);
        }
    }
}