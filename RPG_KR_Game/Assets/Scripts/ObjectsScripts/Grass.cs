using System;
using System.Collections;
using UnityEngine;
using Interfaces.MapInterfaces;
using Random = UnityEngine.Random;

namespace ObjectsScripts
{
    public class Grass : MonoBehaviour, IGrow, IDecrease, IDie, IRandomPosition
    {
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            StartCoroutine(startRigitbody());
        }

        private IEnumerator startRigitbody()
        {
            _rb.WakeUp();
            yield return new WaitForSeconds(0.1f);
            _rb.Sleep();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (LayerMask.LayerToName(other.gameObject.layer) == "Mooses")
            {
                die();
            }
            else if (LayerMask.LayerToName(other.gameObject.layer) == "Grass")
            {
                transform.Translate(0.2f * (GetPosition().x - other.gameObject.transform.position.x), 
                    0.2f * (GetPosition().y - other.gameObject.transform.position.y), 0);
            }
        }

        private Vector3 GetPosition()
        {
            return gameObject.transform.position;
        }

        public Vector2 getRandomPosition()
        {
            return new Vector2(Random.Range(GetPosition().x - 0.4f, GetPosition().x + 0.4f),
                Random.Range(GetPosition().y - 0.4f, GetPosition().y + 0.4f));
        }

        public void grow()
        {
            Instantiate(gameObject, getRandomPosition(), Quaternion.identity, transform);
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