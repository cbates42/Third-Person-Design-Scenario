using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float accelerationforce = 10;

    [SerializeField]
    private float MaxSpeed = 5;

    private new Rigidbody rigidbody;
    private Vector2 input;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var InputDirection = new Vector3(input.x, 0, input.y);

        if(rigidbody.velocity.magnitude < MaxSpeed)
        {
            rigidbody.AddForce(InputDirection * accelerationforce);

        }

    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

    }

}
