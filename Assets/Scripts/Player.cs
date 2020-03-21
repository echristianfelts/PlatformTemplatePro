using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    public float horizontalInput;
    public float verticalInput;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {


        // get horiz input

        horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput *= speed;
        // define move based on input
        moveDirection = new Vector3(horizontalInput, 0.0f, 0.0f);

        //  move in that dir

        _controller.Move(moveDirection *Time.deltaTime);



    }
}
