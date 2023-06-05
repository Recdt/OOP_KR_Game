using UnityEngine;

namespace Behavior
{
    public class Flee: DesiredVelocityProvider
    {
        public Transform objectToFlee;
        public override Vector3 GetDesiredVelocity()
        {
            return -(objectToFlee.position - transform.position).normalized * Animal.VelocityLimit;
        }
    }
}