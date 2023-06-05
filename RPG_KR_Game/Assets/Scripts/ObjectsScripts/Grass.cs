using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces.MapInterfaces;
using Unity.VisualScripting;

namespace ObjectsScripts
{
    public class Grass : MonoBehaviour, MapObjInterface
    {
        private MapObject info;
        private int amount;

        Grass()
        {
            amount = 0;
        }

        void Start ()
        {

        }

        void Update()
        {
            
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