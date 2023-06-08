using System;
using System.Collections;
using GlobalEvents;
using Interfaces.MapInterfaces;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

namespace SpawnSystem
{
    public class MapObjSpawn : MonoBehaviour
    {
        private Vector3 _map;
        private int _grassAmount = 400;
        private int _grassUpdateAmount = 10;
        private int _wolfAmount = 20;
        private int _rabbitAmount = 30;
        
        [SerializeField] private GameObject _grassExample;
        [SerializeField] private GameObject _wolfExample;
        [SerializeField] private GameObject _rabbitExample;
        
        private GrassSpawn _grassSpawn;
        private AnimalSpawn _animalSpawn;
        private Rain _rainEvent;
        
        private float _interval = 5f;
        private float _timer;

        private void Start()
        {
            _map.X = 200;
            _map.Y = 100;

            _grassSpawn = gameObject.AddComponent<GrassSpawn>();
            _animalSpawn = gameObject.AddComponent<AnimalSpawn>();
            
            _rainEvent = gameObject.AddComponent<Rain>();
            _grassSpawn.SetRainEvent(_rainEvent);
            SpawnAll();
            _timer = _interval;
        }
        
        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                StartCoroutine(_grassSpawn.Spawn(_grassExample, _map, _grassUpdateAmount));
                _timer = _interval;
            }
        }

        private void SpawnAll()
        {
            StartCoroutine(_grassSpawn.Spawn(_grassExample, _map, _grassAmount));
            StartCoroutine(_animalSpawn.Spawn(_wolfExample, _map, _wolfAmount));
            StartCoroutine(_animalSpawn.Spawn(_rabbitExample, _map, _rabbitAmount));
        }

        private void SpawnSomeGrass()
        {
            
        }
    }
}