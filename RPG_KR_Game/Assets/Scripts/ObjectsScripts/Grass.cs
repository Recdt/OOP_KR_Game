using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces.MapInterfaces;
using Unity.VisualScripting;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

namespace ObjectsScripts
{
    public class Grass : MonoBehaviour, Grow, Decrease, Die
    {
        private MapObject _objInfo;

        private void Start()
        {
            grow();
        }

        Vector3 getPosition()
        {
            return _objInfo.getPosition();
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (LayerMask.LayerToName(other.gameObject.layer) == "Grass")
            {
                transform.Translate(0.2f * (gameObject.transform.position.x - other.gameObject.transform.position.x), 
                    0.2f * (gameObject.transform.position.y - other.gameObject.transform.position.y), 0);
            }
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
            var randomPosition = new Vector2(Random.Range(gameObject.transform.position.x - 0.4f, gameObject.transform.position.x + 0.4f), 
                Random.Range(gameObject.transform.position.y - 0.4f, gameObject.transform.position.y + 0.4f));
            Instantiate(gameObject, randomPosition, Quaternion.identity, transform);
        }

        public void decrease()
        {
            die();
        }

        public void die()
        {
            Destroy(gameObject);
        }
    }
}