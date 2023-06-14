using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed, rotSpeed,jumpForce;
    bool jumpFlag;
    public VariableJoystick joystick;
    public Rigidbody rb;
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void FixedUpdate()
    {
        // Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            // Rotate the player
            Vector3 rotation = new Vector3(0f, joystick.Horizontal * rotSpeed * Time.deltaTime, 0f);
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

            // Move the player
            Vector3 movement = -transform.forward * joystick.Vertical * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }
    public void Jump()
    {
        if (!jumpFlag)
        {
            jumpFlag = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Invoke("jumpDuration", 1.5f);
        }
    }
    void jumpDuration()
    {
        jumpFlag = false;
    }
}
