using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement2 : MonoBehaviour
{
    [Header("References")]
    public Transform cameraTransform; // Taruh Main Camera di sini
    private Rigidbody rb;

    [Header("Movement Settings")]
    public float moveSpeed = 6f;
    public float rotationSpeed = 10f;
    public float jumpForce = 5f;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        // Cek apakah menyentuh tanah
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Arah berdasarkan kamera
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Gerak maju sesuai arah kamera
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 moveVelocity = moveDir.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
        }
        else
        {
            // Jika tidak bergerak, tetap jaga kecepatan Y (gravitasi)
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
