using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class MainCharacterMovment : MonoBehaviour, IMovment
{
    #region Properties

    private float speed = 15;
    private float horizontal, vertical;
    private Vector3 direction;
    
    private float zoomSpeed = 500f;

    #endregion
    #region Methods

    public void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, vertical);
        transform.position += direction * speed * Time.deltaTime;
    }
    
    private void LateUpdate()
    {
        Movement();
        
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        
        if (scrollDelta != 0)
        {
            Camera.main.orthographicSize -= scrollDelta * zoomSpeed * Time.deltaTime;
        }
    }
    #endregion
}
