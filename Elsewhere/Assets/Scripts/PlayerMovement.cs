using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5.0f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 3.0f;
    public Transform cameraHolder;
    public float minLookAngle = -60f;
    public float maxLookAngle = 60f;

    [Header("Jump Settings")]
    public float jumpForce = 6.0f;
    public float fallMultiplier = 5.0f;
    public float lowJumpMultiplier = 3.0f;
    private int jumpCount = 0;
    private const int maxJumps = 2;

    [Header("Air Control")]
    public float airControlMultiplier = 0.4f;


    private float xRotation = 0f;
    private Rigidbody rb;
    private bool isGrounded = false;
    private bool wasGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpCount++;
        }

        ApplyBetterJumpPhysics();
        LookAround();
    }

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 forward = cameraHolder.forward;
        Vector3 right = cameraHolder.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveInput = (forward * moveVertical + right * moveHorizontal).normalized;

        Vector3 desiredVelocity;

        if (isGrounded)
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.2f))
        {
            Vector3 slopeNormal = hit.normal;
            Vector3 slopeDirection = Vector3.ProjectOnPlane(moveInput, slopeNormal).normalized;
            desiredVelocity = slopeDirection * speed;
        }
        else
        {
            desiredVelocity = moveInput * speed;
        }
    }
    else
    {
        desiredVelocity = moveInput * speed * airControlMultiplier;
    }

        rb.velocity = new Vector3(desiredVelocity.x, rb.velocity.y, desiredVelocity.z);
    }




    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minLookAngle, maxLookAngle);
        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void ApplyBetterJumpPhysics()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (isGrounded && !wasGrounded)
        {
            Debug.Log("Landed on ground.");
        }
        else if (!isGrounded && wasGrounded)
        {
            Debug.Log("Left the ground.");
        }

        wasGrounded = isGrounded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
            Debug.Log("Landed on ground (trigger).");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Left the ground (trigger).");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * 0.5f, 0.2f);
    }
}
