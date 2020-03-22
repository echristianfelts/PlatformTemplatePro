using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform _TargetA, _TargetB;
    private Transform _targetPos;
    public float _speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        _targetPos = _TargetB;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, _targetPos.position, Time.deltaTime * _speed);
        if (this.transform.position == _targetPos.position)
        {
            if(_targetPos == _TargetB)
            {
                _targetPos = _TargetA;
            } else
            {
                _targetPos = _TargetB;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Moving Platform Trigger.");

        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
