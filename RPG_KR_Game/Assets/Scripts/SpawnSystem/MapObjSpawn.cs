using System;
using System.Collections;
using Interfaces.MapInterfaces;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

namespace SpawnSystem
{
    public class MapObjSpawn : MonoBehaviour
    {
        private Vector3 _map;
        private int _grassAmount;
        [SerializeField] private GameObject _grassExample;
        private GrassSpawn _grassSpawn;

        private void Start() //delete after checking
        {
            _map.X = 100;
            _map.Y = 100;
            _grassAmount = 1000;
            _grassSpawn = gameObject.AddComponent<GrassSpawn>();
            SpawnAll();
        }

        public MapObjSpawn(Vector3 map, int grassAmount, GameObject grass)
        {
            _map = map;
            _grassAmount = grassAmount;
            _grassExample = grass;
            _grassSpawn = gameObject.AddComponent<GrassSpawn>();
        }

        public void SpawnAll()
        {
            StartCoroutine(_grassSpawn.Spawn(_grassExample, _map, _grassAmount));
        }
    }
}