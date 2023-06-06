using System.Collections;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace SpawnSystem
{
    public class GrassSpawn : MonoBehaviour, ISpawn
    {
        private readonly RandomPosGenerator _randomPosGenerator;

        public GrassSpawn()
        {
            _randomPosGenerator = new RandomPosGenerator();
        }

        public IEnumerator Spawn(GameObject example, Vector3 map, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(example, _randomPosGenerator.GetRandomPosition(map), Quaternion.identity, transform);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}