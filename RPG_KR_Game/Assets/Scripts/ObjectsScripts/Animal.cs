using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    #region Properties

    private Vector3 velocity;
    private Vector3 acceleration;
    
    [SerializeField] private float mass = 1;
    [SerializeField, Range(1, 20)] private float velocityLimit = 3;
    [SerializeField, Range(1, 50)] private float steeringForceLimit = 5;
    private const float Epsilon = 0.05f;

    public float VelocityLimit => velocityLimit;
    public Vector3 Velocity => velocity;
    
    #endregion
    
    #region Methods

    public void ApplyForce(Vector3 force)
    {
        force /= mass;
        acceleration += force;
    }
    public void ApplyFriction()
    {
        var friction = -velocity.normalized * 0.5f;
        ApplyForce(friction);
    }

    public void ApplySteeringForce()
    {
        var providers = GetComponents<DesiredVelocityProvider>();
        var steering = Vector3.zero;
        foreach (var provider in providers)
        {
            var desiredVelocity = provider.GetDesiredVelocity() * provider.Weight; //
            steering += desiredVelocity - velocity;
                        
        }
        ApplyForce(Vector3.ClampMagnitude(steering - velocity, steeringForceLimit));
    }

    public void ApplyForces()
    {
        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, velocityLimit);
                
                
        if (velocity.magnitude < Epsilon)
        {
            velocity = Vector3.zero;
            return;
        }

        transform.position += velocity * Time.deltaTime;
        acceleration = Vector3.zero;
    }
   
    
    void Update()
    {
        ApplyFriction();
        ApplySteeringForce();
        ApplyForces();
    }
    

    #endregion
}
