using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GlobalEvents
{
    public class Rain : MonoBehaviour, ISubject
    {

        public string State { get; set; } = "rain";
        private List<IObserver> _observers = new List<IObserver>();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Notify();
            }
        }
        

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
            observer.Subscribed(this);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
            Debug.Log(_observers.Count);
        }

        public void Notify()
        {
            // foreach (var observer in _observers)
            // {
            //     observer.UpdateObs(this);
            // }
            Debug.Log(_observers.Count);

            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].UpdateObs(this);
            }
        }
    }
}