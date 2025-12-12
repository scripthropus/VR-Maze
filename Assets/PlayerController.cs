using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [Header("移動")]
    public float moveSpeed = 5f;

    [Header("参照")]
    public Transform cameraTransform;

    [Header("モード")]
    public bool isPCMode = true;
    public float mouseSensitivity = 2f;

    private Rigidbody rb;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Rigidbodyの設定を強制
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        if (isPCMode)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        if (isPCMode)
        {
            MouseLook();
        }

        Move();
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Y軸回転（左右を向く）
        transform.Rotate(Vector3.up * mouseX);

        // X軸回転（上下を見る）
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void Move()
    {
        // 入力を取得
        float horizontal = Input.GetAxis("Horizontal"); // A/D
        float vertical = Input.GetAxis("Vertical");     // W/S

        // カメラの向きを基準に移動方向を計算
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Y成分を0にして水平移動のみ（これが重要！）
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // 移動ベクトルを計算
        Vector3 moveDirection = forward * vertical + right * horizontal;

        // 速度を設定（X, Z のみ。Y は重力に任せる）
        rb.velocity = new Vector3(
            moveDirection.x * moveSpeed,
            rb.velocity.y,  // 重力を保持
            moveDirection.z * moveSpeed
        );
    }
}