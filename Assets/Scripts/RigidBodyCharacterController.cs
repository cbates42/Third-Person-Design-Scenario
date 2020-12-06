using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidBodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float accelerationForce = 10f;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    private PhysicMaterial StoppingPhysicsMaterial, MovingPhysicsMaterial;

    [SerializeField]
    [Range(0, 1)]
    [Tooltip("0 = no turning. 1 = instant turning")]
    private float turnspeed = 0.1f;


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
        Vector3 cameraRelativeInputDirection = GetCameraRelativeInputDirection();
        Move(cameraRelativeInputDirection);

        UpdatePhysicsMaterial();

        RotateToFaceMoveInputDirection(cameraRelativeInputDirection);
    }

    /// <summary>
    /// Turn the character to face the direction it wants to move in.
    /// </summary>
    /// <param name="cameraRelativeInputDirection"></param>
    private void RotateToFaceMoveInputDirection(Vector3 movementDirection)
    {
        if (movementDirection.magnitude > 0)
        {
            var targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnspeed);
        }
    }

    /// <summary>
    /// Moves the player ina  direction based on its max speed and acceleration.
    /// </summary>
    /// <param name="moveDirection">The direction to move in.</param>
    private void Move(Vector3 moveDirection)
    {
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(moveDirection * accelerationForce, ForceMode.Acceleration);
        }
    }

    /// <summary>
    /// Updates the physics material to a low friction option if the player is trying to move,
    /// or a low friction option if they're trying to stop.
    /// </summary>
    private void UpdatePhysicsMaterial()
    {
        collider.material = input.magnitude > 0 ? MovingPhysicsMaterial : StoppingPhysicsMaterial;
    }

    /// <summary>
    /// Uses the Input Vector to create a camera relative version
    /// so the player can move based on the camera's forward.
    /// </summary>
    /// <returns>Returns the camera relative input direction</returns>
    private Vector3 GetCameraRelativeInputDirection()
    {
        Vector3 InputDirection = new Vector3(input.x, 0, input.y);

        Vector3 cameraFlattenedForward = Camera.main.transform.forward;
        cameraFlattenedForward.y = 0;
        var cameraRotation = Quaternion.LookRotation(cameraFlattenedForward);

        Vector3 cameraRelativeInputDirectionToReturn = cameraRotation * InputDirection;
        return cameraRelativeInputDirectionToReturn;
    }


    /// <summary>
    /// This event handler is called from the Player Input component
    /// using the new Input System.
    /// </summary>
    /// <param name="context">Vector 2 representing move input.</param>
    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }
}
