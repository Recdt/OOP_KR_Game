using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    [SerializeField] private Vector3 mapSize = new Vector3 (100f, 100f, 0f);

    Vector3 getMapSize()
    {
        return mapSize;
    }

    bool isOnMap(Vector3 position)
    {
        if (position.x < mapSize.x && position.y < mapSize.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
