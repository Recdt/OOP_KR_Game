using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace SpawnSystem
{
    public class RandomPosGenerator
    {
        public Vector2 GetRandomPosition(Vector3 range)
        {
            var randomPosition = new Vector2(Random.Range((-range.X) / 2, range.X / 2), 
                Random.Range(-range.Y / 2, range.Y / 2));
            return randomPosition;
        }
    }
}