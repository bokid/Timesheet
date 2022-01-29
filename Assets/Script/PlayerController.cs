using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horInput;
    private float vertInput;
    //public Animator animator;
    public float speed;
    private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        vertInput = UnityEngine.Input.GetAxisRaw("Vertical");
        //animator.SetFloat("Speed", Mathf.Abs(horInput));

        player.velocity = new Vector2(horInput * speed, vertInput * speed);
       
         
    }
}
