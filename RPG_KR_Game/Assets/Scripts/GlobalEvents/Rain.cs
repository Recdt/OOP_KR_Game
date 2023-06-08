using System;
using System.Collections.Generic;
using System.IO;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GlobalEvents
{
    public class Rain : MonoBehaviour, ISubject
    {

        public string State { get; set; } = "rain";
        private List<IObserver> _observers = new List<IObserver>();

        private string _filePath = "state_grass.txt";
        private float _interval = 1f;
        private float _timer;

        private void Start()
        {
            _timer = _interval;
            File.WriteAllText(_filePath, string.Empty);
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                saveStatistic();
                _timer = _interval;
            }
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
            var amountOfGrows = (int)(Random.Range(0.3f * _observers.Count, 0.7f * _observers.Count));

            for (int i = 0; i < amountOfGrows; i++)
            {
                _observers[i].UpdateObs(this);
            }
        }

        private void saveStatistic()
        {
            writeToFile(getStatistic());
        }

        private string getStatistic()
        {
            return _observers.Count.ToString();
        }

        private void writeToFile(string text)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(text);
            }
        }
    }
}