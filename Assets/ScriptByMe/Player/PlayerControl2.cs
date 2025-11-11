using System.Collections;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Vector3 playerVelocity;
    [SerializeField] bool groundedPlayer;
    [SerializeField] float playerSpeed;
    [SerializeField] float gravityValue;
    [SerializeField] GameObject activeChar;
    [SerializeField] float speed = 4f;
    [SerializeField] float jumpHeight = 1.2f;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool isRunning = false;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] Transform cameraTransform; // <— referensi kamera

    void Start()
    {
        playerSpeed = 4f;
        gravityValue = -20f;

        if (cameraTransform == null)
            cameraTransform = Camera.main.transform; // otomatis ambil kamera utama
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        // Input dari WASD
        float moveX = Input.GetAxis("Horizontal"); // A / D
        float moveZ = Input.GetAxis("Vertical");   // W / S

        // Arah relatif terhadap kamera
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Kombinasikan input dengan arah kamera
        Vector3 moveDir = (camForward * moveZ + camRight * moveX).normalized;

        // Rotasi player ke arah gerak
        if (moveDir.magnitude >= 0.1f)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotateSpeed);
        }

        // Cek tombol lari
        if (Input.GetKey(KeyCode.LeftShift) && moveDir.magnitude > 0.1f)
        {
            isRunning = true;
            speed = 10f;

            if (!isJumping)
            {
                Animator anim = activeChar.GetComponent<Animator>();
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Rig_run"))
                    anim.Play("Rig_run");
            }
        }
        else
        {
            if (isRunning)
            {
                StartCoroutine(stopRun());
                speed = 4f;
            }
        }

        // Gerakkan player
        controller.Move(moveDir * speed * Time.deltaTime);

        // ======= LOMPAT (sementara dikomentari) =======
        /*
        if (Input.GetKey(KeyCode.Space) && groundedPlayer && !isJumping)
        {
            isJumping = true;
            activeChar.GetComponent<Animator>().Play("Rig_jump_start");
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
            StartCoroutine(ResetJump());
        }
        */
        // ==============================================

        // Gravitasi
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Animasi jalan / idle
        if (!isRunning && moveDir.magnitude > 0.1f && !isJumping)
        {
            Animator anim = activeChar.GetComponent<Animator>();
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Rig_walk"))
                anim.Play("Rig_walk");
        }
        else if (!isRunning && !isJumping && moveDir.magnitude <= 0.1f)
        {
            Animator anim = activeChar.GetComponent<Animator>();
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Rig_idle"))
                anim.Play("Rig_idle");
        }
    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(1f);
        isJumping = false;
    }

    IEnumerator stopRun()
    {
        yield return new WaitForSeconds(0.1f);
        isRunning = false;
    }
}
