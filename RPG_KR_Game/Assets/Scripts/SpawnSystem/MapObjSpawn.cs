using System;
using System.Collections;
using Interfaces.MapInterfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnSystem
{
    public class MapObjSpawn : MonoBehaviour, RandomPosition
    {
        [SerializeField] private BoxCollider2D map;
        [SerializeField] private int grassAmount = 10;
        [SerializeField] private GameObject grassExample;

        private void Start()
        {
            StartCoroutine(spawnGrass());
        }

        public Vector2 getRandomPosition()
        {
            var randomPosition = new Vector2(Random.Range(-map.size.x / 2, map.size.x / 2), 
                Random.Range(-map.size.y / 2, map.size.y / 2));
            return randomPosition;
        }
        private IEnumerator spawnGrass()
        {
            for (int i = 0; i < grassAmount; i++)
            {
                Instantiate(grassExample, getRandomPosition(), Quaternion.identity, transform);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}