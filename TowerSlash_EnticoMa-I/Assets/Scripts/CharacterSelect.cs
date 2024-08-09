using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    private string selectedCharacter;

    private void Start()
    {
        Debug.Log("chara load");
    }
    public void OnButtonPressNormal()
    {
        selectedCharacter = "Default";
        StartGame();
    }
    public void OnButtonPressTank()
    {
        selectedCharacter = "Tank";
        StartGame();
    }
    public void OnButtonPressSpeed()
    {
        selectedCharacter = "Speed";
        StartGame();
    }

    public void StartGame()
    {
        PlayerPrefs.SetString("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene("TowerSlashGame");
    }
}
