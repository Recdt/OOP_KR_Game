using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using Interfaces.MapInterfaces;
using SpawnSystem;
using Random = UnityEngine.Random;

namespace ObjectsScripts
{
    public class Grass : MonoBehaviour, IGrow, IDie, IObserver
    {
        private Rigidbody2D _rb;
        private NearPosGenerator _nearPosGenerator;
        private ISubject _rainEvent;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _nearPosGenerator = new NearPosGenerator();
            StartCoroutine(StartRigidbody());
        }

        private IEnumerator StartRigidbody()
        {
            //GetComponent<Collider2D>().isTrigger = true;
            _rb.WakeUp();
            yield return new WaitForSeconds(0.1f);
            _rb.Sleep();
            //GetComponent<Collider2D>().isTrigger = false;
        }
        
        // private void OnCollisionEnter2D(Collision2D other)
        // {
        //     if (LayerMask.LayerToName(other.gameObject.layer) == "Mooses" ||
        //         LayerMask.LayerToName(other.gameObject.layer) == "Victim") {
        //         die();
        //     }else
        //     {
        //         GetComponent<Collider2D>().isTrigger = true;
        //     }
        // }

        // private void OnTriggerExit2D(Collider2D other)
        // {
        //     GetComponent<Collider2D>().isTrigger = false;
        // }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (LayerMask.LayerToName(other.gameObject.layer) == "Grass")
            {
                transform.Translate(0.2f * (GetPosition().x - other.gameObject.transform.position.x), 
                    0.2f * (GetPosition().y - other.gameObject.transform.position.y), 0);
            }
        }


        private Vector3 GetPosition()
        {
            return gameObject.transform.position;
        }

        public void grow()
        {
            var copy = Instantiate(gameObject, _nearPosGenerator.GetNearPosition(GetPosition(), new Vector3(0.4f, 0.4f, 0f)), Quaternion.identity, transform);
            var copyInterface = copy.GetComponent<IObserver>();

            foreach (Transform child in copy.transform)
            {
                Destroy(child.gameObject);
            }
            
            if (copyInterface != null)
            {
                _rainEvent.Attach(copyInterface);
            }
        }

        public void die()
        {
            if (_rainEvent != null)
            {
                _rainEvent.Detach(this);
            }
            Destroy(gameObject);
        }

        public void UpdateObs(ISubject subject)
        {
            StartCoroutine(growDelay());
        }

        private IEnumerator growDelay()
        {
            yield return new WaitForSeconds(0.5f);
            grow();
        }

        public void Subscribed(ISubject subject)
        {
            _rainEvent = subject;
        }
    }
}