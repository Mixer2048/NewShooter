using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool grounded;

    [Range(1f, 100f)]
    public float playerSpeed = 2.0f;
    [Range(1f, 100f)]
    public float jumpHeight = 1.0f;

    public float gravityValue = -9.81f;

    void Start() => controller = GetComponent<CharacterController>();

    private void playerMove()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move.Normalize();//Чтобы персонаж не ускорялся придвижении одновременно вперёд и вбок
        controller.Move(transform.TransformDirection(move) * Time.deltaTime * playerSpeed);
    }

    void playerJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }

    void LateUpdate()
    {
        grounded = controller.isGrounded;

        if (grounded && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        playerMove();
        playerJump();

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
