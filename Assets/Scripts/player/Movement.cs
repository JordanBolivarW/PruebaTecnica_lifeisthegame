using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float speed = 2, runMultiplier = 2, gravity = 9.8f;
    [Range(0.5f, 5f)][SerializeField] float jumpHeigth = 1f;

    Vector3 normalDirection, gravityV, jump;
    float x, z, normalAngleD, normalAngleR, Jmagnitude, baseMovementModifier, angleModifier, movementModifierX, movementModifierZ, jumpModifier;
    bool isGrounded, jumping;

    Vector3 allMovement, baseMovement, gravityMovement;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        allMovement = Vector3.zero;
        baseMovement = Vector3.zero;
        gravityMovement = Vector3.zero;
        jump = Vector3.zero;
    }
    private void Update()
    {
        baseMovement = BaseMovement();
        gravityMovement = GravityMovement();
        jump = Jump();

        allMovement = (baseMovement * Running()) + gravityMovement + jump;

        controller.Move(allMovement * Time.deltaTime);
    }

    Vector3 BaseMovement()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        baseMovement = Vector3.ClampMagnitude((transform.right * x + transform.forward * z), 1) * speed;

        return baseMovement;
    }

    float Running()
    {
        float multiplier = 1;
        if (Input.GetKey(KeyCode.LeftShift))
            multiplier = runMultiplier;
        else
            multiplier = 1;

        return multiplier;
    }

    Vector3 Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = Vector3.up * Mathf.Sqrt(jumpHeigth * 2 * gravity);
            jump.y -= jumpModifier;
            jumping = true;
            Invoke("NoJump", 0.2f);
        }
        else if (isGrounded)
        {
            jumpModifier = 0;
            jump = Vector3.zero;
        }

        return jump;
    }
    void NoJump()
    {
        jumping = false;
    }

    Vector3 GravityMovement()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out hit, 0.6f) && !jumping)
        {
            isGrounded = true;
            gravityMovement = Vector3.zero;
        }
        else
        {
            isGrounded = false;
            gravityMovement += Vector3.down * gravity * Time.deltaTime;
        }

        return gravityMovement;
    }
}
