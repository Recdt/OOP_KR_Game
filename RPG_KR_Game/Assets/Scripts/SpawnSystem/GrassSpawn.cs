using System.Collections;
using GlobalEvents;
using Interfaces;
using ObjectsScripts;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace SpawnSystem
{
    public class 
        GrassSpawn : MonoBehaviour, ISpawn
    {
        private readonly RandomPosGenerator _randomPosGenerator;
        private Rain _rain;

        public GrassSpawn()
        {
            _randomPosGenerator = new RandomPosGenerator();
        }

        public void SetRainEvent(Rain rain)
        {
            _rain = rain;
        }

        public IEnumerator Spawn(GameObject example, Vector3 map, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var copy = Instantiate(example, _randomPosGenerator.GetRandomPosition(map), Quaternion.identity, transform);
                var copyInterface = copy.GetComponent<IObserver>();

                if (copyInterface != null)
                {
                    _rain.Attach(copyInterface);
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
}