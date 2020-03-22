using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        // _player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player _player = other.GetComponent<Player>();

            if (_player != null)
            {
                _player.TotalCoins(1);
            }
            Destroy(this.gameObject);
        }

    }
}
