using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class MapObject : MonoBehaviour
{
    private Vector3 _position;
    private int _objType;

    Vector3 getPosition()
    {
        return _position;
    }

    void setPosition(Vector3 newPosition)
    {
        _position = newPosition;
    }

    int getObjectType()
    {
        return _objType;
    }

    void setObjectType(int newType)
    {
        _objType = newType;
    }
    
}
