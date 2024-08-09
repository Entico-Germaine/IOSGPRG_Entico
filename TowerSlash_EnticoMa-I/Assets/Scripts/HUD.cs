using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI playerGauge;
    public Button dash;
    public bool isPressed;

    private void Start()
    {
        GameManager.Instance.hud = this;
        dash.gameObject.SetActive(false);
        isPressed = false;
    }

    void Update()
    {
        playerHealth.text = GameManager.Instance.player.Health.ToString();
        playerGauge.text = GameManager.Instance.player.abilityGaugeCurr.ToString();

        if(GameManager.Instance.player.DashReady == true)
        {
            dash.gameObject.SetActive(true);
        }
    }

    public void OnPress()
    {
        dash.gameObject.SetActive(false);
        GameManager.Instance.player.abilityGaugeCurr = 0;
        isPressed = true;
    }
}
