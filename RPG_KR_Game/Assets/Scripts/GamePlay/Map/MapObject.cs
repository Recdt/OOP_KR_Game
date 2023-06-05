using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class MapObject : MonoBehaviour
{
    private Vector3 _position;
    private int _objType;

    public Vector3 getPosition()
    {
        return _position;
    }

    public void setPosition(Vector3 newPosition)
    {
        _position = newPosition;
    }

    public int getObjectType()
    {
        return _objType;
    }

    public void setObjectType(int newType)
    {
        _objType = newType;
    }
    
}
