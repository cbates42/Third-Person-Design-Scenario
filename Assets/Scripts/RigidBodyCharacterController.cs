using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float accelerationforce = 10;

    [SerializeField]
    private float MaxSpeed = 5;

    [SerializeField]
    private PhysicMaterial StoppingPhysicsMaterial, MovingPhysicsMaterial;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        var InputDirection = new Vector3(input.x, 0, input.y);

        if(rigidbody.velocity.magnitude < MaxSpeed)
        {
            rigidbody.AddForce(InputDirection * accelerationforce);

        }

        if (InputDirection.magnitude > 0)
        {
            collider.material = MovingPhysicsMaterial;
        }

        else
        {
            collider.material = StoppingPhysicsMaterial;
        }    
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

    }

}
