using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float horInput;
    private float vertInput;
    //public Animator animator;
    public float speed;
    private Rigidbody2D player;
    private Vector2 movementInput = Vector2.zero;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    // Start is called before the first frame update

    private Controls controls;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        controls.Player.Shoot.performed += ctx => PlayerShoot();
    }

    private void PlayerShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horInput = movementInput.x;
        vertInput = movementInput.y;
        //animator.SetFloat("Speed", Mathf.Abs(horInput));
        player.velocity = new Vector2(horInput * speed, vertInput * speed);
    }

    public void onMove(InputAction.CallbackContext context){
        movementInput = context.ReadValue<Vector2>();
    }
}
