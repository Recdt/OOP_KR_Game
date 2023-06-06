using UnityEngine;

namespace ObjectsScripts
{
    public class NearPosGenerator
    {
        public Vector2 GetNearPosition(Vector3 center, Vector3 range)
        {
            var randomPosition = new Vector2(Random.Range(center.x - range.x, center.x + range.x), 
                Random.Range(center.y - range.y, center.y + range.y));
            return randomPosition;
        }
    }
}