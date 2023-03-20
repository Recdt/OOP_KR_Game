using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class MainCharacterMovment : MonoBehaviour, IMovment
{
    #region Properties

    [SerializeField,Range(5,30)]private float speed = 5;
    private float horizontal, vertical;
    private Vector3 direction;

    #endregion
    #region Methods

    public Vector3 Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, vertical);
        return direction;
    }
    
    private void Update()
    {
        transform.position += Movement() * speed * Time.deltaTime;
    }
    #endregion
}
