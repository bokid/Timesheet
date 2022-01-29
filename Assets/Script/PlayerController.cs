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
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
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
