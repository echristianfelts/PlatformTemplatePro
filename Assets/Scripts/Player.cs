﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    [SerializeField]
    private int _coins;
    private UIManager _uiManager;
    [SerializeField]
    private int _lives = 3;
    public int coins;
    private Vector3 direction;
    private Vector3 velocity;
    private bool _canWallJump = false;
    private Vector3 _wallSurfaceNormal;
    private float _pushPower = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL."); 
        }

        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");


        if (_controller.isGrounded == true)
        {
            _canWallJump = true;
            direction = new Vector3(horizontalInput, 0, 0);
            velocity = direction * _speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _canWallJump == false)
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && _canWallJump == true)
            {
                _yVelocity = _jumpHeight;
                velocity = _wallSurfaceNormal * _speed;
                //velocity = surfacenormal of wall.

            }

            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);


    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //check for the moving box.
        if (hit.transform.tag == "Movable")
        {
            //confirm it has a rigid body
            Rigidbody box = hit.collider.GetComponent<Rigidbody>();

            if (box != null)
            {
                Vector3 pushDirection = new Vector3(hit.moveDirection.x,0,0);

                // apply push
                box.velocity = pushDirection * _pushPower;

            }

        }
        //
        //declare Pushpower as variable on top.

        //calculate new move direction

        //push..!!  (using moving box velocity...)


        //if not grounded and not touching a wall
        if (_controller.isGrounded == false && hit.transform.tag == "Wall")
        {
            Debug.Log("Player is hitting somthing...!!!");
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
            _wallSurfaceNormal = hit.normal;
            _canWallJump = true;
        }


    }


    public void AddCoins()
    {
        _coins++;
        coins = _coins;
        _uiManager.UpdateCoinDisplay(_coins);
    }

    public void Damage()
    {
        _lives--;

        _uiManager.UpdateLivesDisplay(_lives);

        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }

    public int CoinCount()
    {
        return _coins;
    }
}
