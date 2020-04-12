using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    private bool _goingDown = false;
    [SerializeField]
    private Transform _origin, _target;
    private Transform _targetPos;
    private float _speed=3.0f;


    // Start is called before the first frame update
    void Start()
    {
        _targetPos = _target;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if (_goingDown == true)
        {
            Debug.Log("Elevator has heard the Elevator Panel.");

            transform.position = Vector3.MoveTowards(transform.position, _targetPos.position, Time.deltaTime * _speed);
            if (this.transform.position == _targetPos.position && _goingDown == true)
            {
                if (_targetPos == _target)
                {
                    _targetPos = _origin;
                    _goingDown = false;
                }
                else
                {
                    _targetPos = _target;
                    _goingDown = false;
                }
            }
        }
        // if going down == true
        // take current pos to targer pos
        // else
        // move up form current pos to other target.
        //
    }


    public void CallElevator()
    {
        //Know current posiiton
        _goingDown = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }


}
