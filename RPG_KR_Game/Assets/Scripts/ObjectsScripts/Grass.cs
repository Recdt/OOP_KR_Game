using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces.MapInterfaces;
using Unity.VisualScripting;
using Vector3 = System.Numerics.Vector3;

namespace ObjectsScripts
{
    public class Grass : MonoBehaviour, Grow, Decrease, Die
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LayerMask.LayerToName(other.gameObject.layer) == "Mooses")
            {
                Debug.Log("Grass was eaten");
                die();
            }
        }

        public void grow()
        {
            
        }

        public void decrease()
        {
            
        }

        public void die()
        {
            Destroy(gameObject);
        }
    }
}