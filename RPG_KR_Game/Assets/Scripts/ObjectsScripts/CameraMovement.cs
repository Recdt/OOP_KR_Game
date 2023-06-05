using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//connect this script into camera and choose the object to follow
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject thingToFollow;

    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
