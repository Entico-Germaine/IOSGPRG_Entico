using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Button retry;
    public TextMeshProUGUI gameScore;
    private float playerScore;

    private void Start()
    {
        // playerType = PlayerPrefs.GetString("selectedCharacter");
        playerScore = PlayerPrefs.GetFloat("TotalScore");
        playerScore = Mathf.Floor(playerScore);
        gameScore.text =playerScore.ToString();
    }
    public void OnPress()
    {
        //PlayerPrefs.SetInt("healthCatcher", 1);
        SceneManager.LoadScene("CharacterSelect");
    }
}
