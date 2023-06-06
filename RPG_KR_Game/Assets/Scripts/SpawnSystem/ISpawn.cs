using System.Collections;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace SpawnSystem
{
    public interface ISpawn
    {
        public IEnumerator Spawn(GameObject example, Vector3 map, int amount);
    }
}