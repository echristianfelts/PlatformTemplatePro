using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    public Text _scoreText;

    //Update Coin Counter

    private void Start()
    {
        _scoreText.text = "Collected Coins: " + 00;
    }



    public void UpdateScore(int playerScore)
    {

        _scoreText.text = "Collected Coins: " + playerScore.ToString();

    }

}
