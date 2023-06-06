using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace SpawnSystem
{
    public class RandomPosGenerator
    {
        public Vector2 GetRandomPosition(Vector3 map)
        {
            var randomPosition = new Vector2(Random.Range((-map.X) / 2, map.X / 2), 
                Random.Range(-map.Y / 2, map.Y / 2));
            return randomPosition;
        }
    }
}