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
        private int _grassAmount;
        private int _wolfAmount;
        private int _rabbitAmount;
        
        [SerializeField] private GameObject _grassExample;
        [SerializeField] private GameObject _wolfExample;
        [SerializeField] private GameObject _rabbitExample;
        
        private GrassSpawn _grassSpawn;
        private AnimalSpawn _animalSpawn;
        private Rain _rainEvent;

        private void Start()
        {
            _map.X = 300;
            _map.Y = 300;
            
            _grassAmount = 400;
            _wolfAmount = 10;
            _rabbitAmount = 30;
            
            _grassSpawn = gameObject.AddComponent<GrassSpawn>();
            _animalSpawn = gameObject.AddComponent<AnimalSpawn>();
            
            _rainEvent = gameObject.AddComponent<Rain>();
            _grassSpawn.SetRainEvent(_rainEvent);
            SpawnAll();
        }

        private void SpawnAll()
        {
            StartCoroutine(_grassSpawn.Spawn(_grassExample, _map, _grassAmount));
            StartCoroutine(_animalSpawn.Spawn(_wolfExample, _map, _wolfAmount));
            StartCoroutine(_animalSpawn.Spawn(_rabbitExample, _map, _rabbitAmount));
        }
    }
}