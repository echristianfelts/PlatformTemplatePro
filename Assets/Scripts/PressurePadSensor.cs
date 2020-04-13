using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePadSensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
       if (other.tag == "Movable")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log("Distance between Sensor and Target:" + distance);
            if (distance <= 0.3f)
            {
                // nothing here yet
                other.GetComponent<Rigidbody>().isKinematic = true;
                MeshRenderer renderer = GetComponentInChildren<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.blue;
                }
            }
        }
    }


    //detect moving box
    //when close to sensor
    //disable the box's rigid body or set it to kinimatic
    //change color of pressure pad to blue.
}
