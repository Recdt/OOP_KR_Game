using System;
using System.Collections;
using Interfaces.MapInterfaces;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

namespace SpawnSystem
{
    public class MapObjSpawn : MonoBehaviour, IRandomPosition
    {
        private Vector3 _map;
        private int _grassAmount;
        [SerializeField] private GameObject _grassExample;
        
        private void Start() //delete after checking
        {
            _map.X = 100;
            _map.Y = 100;
            _grassAmount = 1000;
            StartCoroutine(spawnGrass());
        }

        public void oMapObjSpawn(Vector3 map, int grassAmount, GameObject grass)
        {
            _map = map;
            _grassAmount = grassAmount;
            _grassExample = grass;
            StartCoroutine(spawnGrass());
        }

        public Vector2 getRandomPosition()
        {
            var randomPosition = new Vector2(Random.Range((-_map.X) / 2, _map.X / 2), 
                Random.Range(-_map.Y / 2, _map.Y / 2));
            return randomPosition;
        }
        private IEnumerator spawnGrass()
        {
            for (int i = 0; i < _grassAmount; i++)
            {
                Instantiate(_grassExample, getRandomPosition(), Quaternion.identity, transform);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}