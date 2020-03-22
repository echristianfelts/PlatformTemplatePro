using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    public float horizontalInput;
    public float verticalInput;
    public float yVelocity;

    public float speed = 6.0f;
    public float jumpSpeed = 10.0f;
    public float maxGravity = 5.0f;
    public float gravity = 1f;
    public int dJumpFlag = 0;
    private float _gravityLoops = .1f;

    public int score = 0;

    [SerializeField]
    private UI_Manager _uiManager;

    private Vector3 moveDirection = Vector3.zero;

    // variable for player coins



    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        yVelocity = -maxGravity;
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

    }

    // Update is called once per frame
    void Update()
    {

        // reset vert velocity
        if (yVelocity > -maxGravity)
        {
            yVelocity -= (gravity + _gravityLoops);
            _gravityLoops += .1f;
        }
        else
        { _gravityLoops = .1f; }


        // get horiz input

        horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput *= speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_controller.isGrounded == true || dJumpFlag != 1)
            {
                yVelocity = jumpSpeed;
                if (dJumpFlag != 1)
                {
                    dJumpFlag = 1;
                }
            }
        }
        if (_controller.isGrounded == true)
        {
            dJumpFlag = 0;
        }

        // define move based on input
            moveDirection = new Vector3(horizontalInput, yVelocity, 0.0f);

        //  move in that dir

        _controller.Move(moveDirection *Time.deltaTime);

        //TotalCoins(1);



    }


    public void TotalCoins(int EnemyPointValue)
    {
        score += EnemyPointValue;
        _uiManager.UpdateCoinDisplay(score);


    }


}
