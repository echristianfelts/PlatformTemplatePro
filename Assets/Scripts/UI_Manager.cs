using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    public Text _scoreText;
    public Text _livesText;

    //Update Coin Counter

    private void Start()
    {
       // _scoreText.text = "Collected Coins: " + 00;
    }



    public void UpdateCoinDisplay(int playerScore)
    {

        _scoreText.text = "Collected Coins: " + playerScore.ToString();

    }

    public void UpdateLivesDisplay(int playerlives)
    {

        _livesText.text = "Remaining Lives: " + playerlives.ToString();

    }

}
