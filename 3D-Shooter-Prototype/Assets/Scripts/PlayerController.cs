using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float mouseSensitivity = 2f;
    
    [Header("射击设置")]
    public Transform gunPoint;
    public float fireRate = 0.5f;
    public float bulletSpeed = 20f;
    public float bulletDamage = 10f;
    public GameObject bulletPrefab;
    
    private float nextFireTime = 0f;
    private Rigidbody rb;
    private Camera playerCamera;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
        if (gunPoint == null)
            gunPoint = transform.Find("GunPoint");
    }
    
    void Update()
    {
        // 鼠标控制视角
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        transform.Rotate(0, mouseX, 0);
        playerCamera.transform.Rotate(-mouseY, 0, 0);
        
        // 射击控制
        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
        
        // 跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    void FixedUpdate()
    {
        // 移动控制
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed;
        movement = transform.TransformDirection(movement);
        
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
    
    void Fire()
    {
        if (bulletPrefab == null || gunPoint == null) return;
        
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        
        if (bulletRb != null)
        {
            bulletRb.velocity = gunPoint.forward * bulletSpeed;
        }
        
        // 子弹自动销毁
        Destroy(bullet, 3f);
    }
}