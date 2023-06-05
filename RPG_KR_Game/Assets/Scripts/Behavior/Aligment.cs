using System.Collections.Generic;
using UnityEngine;

namespace Behavior
{
    public class Aligment: DesiredVelocityProvider
    {
        public List<Animal> neighbors;
        public override Vector3 GetDesiredVelocity()
        {
            Vector3 velocity = new Vector3(0,0,0);
            if (neighbors.Count == 0)
            {
                return velocity;
            }
            foreach (var neighbor in neighbors)
            {
                velocity += neighbor.Velocity;
            }
            return (velocity / neighbors.Count).normalized * Animal.VelocityLimit;
        }
    }
}