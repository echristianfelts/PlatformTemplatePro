using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    public bool playerTriggerPositive = false;
    //private bool _eKeyTriggerPositive = false;
    public GameObject Call_Button;
    [SerializeField]
    private MeshRenderer _Call_Button_Mesh;
    public int coincost =8;
    //public bool elevatorCall = false;

    public Player _player;
    private Elevator _elevator;

    // Detect Trigger Collison
    // Check for Player
    // Check for E Key
    // Turn the light Blue



    // Start is called before the first frame update
    void Start()
    {   
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();

        if (_elevator == null)
        {
            Debug.Log("The elevator is Null.");
        }


        _player = GameObject.Find("Player").GetComponent<Player>();
        // _player = GameObject.FindGameObjectsWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerTriggerPositive == true && _player.coins >= coincost)
        {
            Call_Button.gameObject.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f, 1f);
            //elevatorCall = true;
            Debug.Log("ElevatorPanel has called the Elevator.");
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerTriggerPositive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerTriggerPositive = false;
            Call_Button.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 1f);
        }
    }


    //----OR----

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" )
        {

            if (Input.GetKeyDown(KeyCode.E) && (_player.coins >= coincost || other.GetComponent<Player>().CoinCount() >= coincost))
            {
                _Call_Button_Mesh.material.color = Color.green;
                //elevatorCall = true;
                _elevator.CallElevator();
            }

        }
    }

    //public void ElevatorCallReset(bool elevatorCallReset)
    //{
        //elevatorCall = elevatorCallReset;
    //}
}

 
