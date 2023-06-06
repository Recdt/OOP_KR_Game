using System;
using System.Collections;
using UnityEngine;
using Interfaces.MapInterfaces;
using SpawnSystem;
using Random = UnityEngine.Random;

namespace ObjectsScripts
{
    public class Grass : MonoBehaviour, IGrow, IDie
    {
        private Rigidbody2D _rb;
        private NearPosGenerator _nearPosGenerator;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _nearPosGenerator = new NearPosGenerator();
            StartCoroutine(StartRigitbody());
        }

        private IEnumerator StartRigitbody()
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

        // public Vector2 getRandomPosition()
        // {
        //     return new Vector2(Random.Range(GetPosition().x - 0.4f, GetPosition().x + 0.4f),
        //         Random.Range(GetPosition().y - 0.4f, GetPosition().y + 0.4f));
        // }

        public void grow()
        {
            Instantiate(gameObject, _nearPosGenerator.GetNearPosition(GetPosition(), new Vector3(0.4f, 0.4f, 0f)), Quaternion.identity, transform);
        }

        public void die()
        {
            Destroy(gameObject);
        }
    }
}