using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behavior
{
    public class Cohesion: DesiredVelocityProvider
    {
        public List<Animal> neighbors;
        public Animal animal;
        public override Vector3 GetDesiredVelocity()
        {
            var neighborsVelocity = new Vector3(0,0,0);
            if (neighbors.Count == 0)
            {
                return neighborsVelocity;
            }
            foreach (var neigbor in neighbors)
            {
                var neighborVelocity = neigbor.Velocity;
                neighborsVelocity += neighborVelocity;
            }

            return (neighborsVelocity / neighbors.Count).normalized * Animal.VelocityLimit;
        }
    }
}