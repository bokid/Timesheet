using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float horInput;
    private float vertInput;
    private SpriteMask flashLightMask;
    public Animator animator;
    public float speed;
    private Rigidbody2D player;
    private Vector2 movementInput = Vector2.zero;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private Vector2 rotationInput = Vector2.zero;

    const string left = "left";
    const string right = "right";
    const string back = "back";
    const string forward = "forward";
    const string idle = "idle";
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        flashLightMask = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        horInput = movementInput.x; 
        vertInput = movementInput.y;

        if (movementInput.x > 0)
        {
            ChangeAnimationState(right);
        }
        else if (movementInput.x < 0)
        {
            ChangeAnimationState(left);
        }

        else if (movementInput.y > 0)
        {
            ChangeAnimationState(back);
        }
        else if (movementInput.y < 0)
        {
            ChangeAnimationState(forward);
        }
        else if (movementInput.x == 0 || movementInput.y == 0)
        {
            ChangeAnimationState(idle);
        }

        player.velocity = new Vector2(horInput * speed, vertInput * speed);
    }

    void Update()
    {
        if(rotationInput.x != 0 && rotationInput.y != 0){
            float angle = Mathf.Atan2(rotationInput.x, rotationInput.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
            player.transform.rotation = Quaternion.Slerp(flashLightMask.transform.rotation, rotation, 0.2f);
        }
    }

    public void onMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void onRotate(InputAction.CallbackContext context)
    {
        rotationInput = context.ReadValue<Vector2>();
    }

    public void onShoot(InputAction.CallbackContext context)
    {
        if(context.performed){
            PlayerShoot();
        }
    }

    private void PlayerShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void ChangeAnimationState(string newAnimation)
    {
        //if (currentAnimaton == newAnimation) return

        animator.Play(newAnimation);
       // currentAnimaton = newAnimation;
    }
}
