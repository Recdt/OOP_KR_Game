using System;
using System.Collections;
using Interfaces.MapInterfaces;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

namespace SpawnSystem
{
    public class MapObjSpawn : MonoBehaviour, RandomPosition
    {
        private Vector3 _map;
        private int _grassAmount;
        private GameObject _grassExample;

        public MapObjSpawn(Vector3 map, int grassAmount, GameObject grass)
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