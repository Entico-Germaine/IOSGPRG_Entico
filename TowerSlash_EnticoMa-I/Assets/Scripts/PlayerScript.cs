using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //private GameObject player;
    [SerializeField]
    private SpriteRenderer playerSprite;
    [SerializeField]
    private Sprite normal;
    [SerializeField]
    private Sprite tank;
    [SerializeField]
    private Sprite speed;

    /*
    [SerializeField]
    private Transform spawnPoint;
    */

    private string playerType;
    public int Health { get; private set; }
    public int Speed { get; private set; }
    public bool DashReady { get; private set; }
    public bool canGetHit;
    public float abilityGaugeCurr;
    public float abilityGaugeTotal;
    private float abilityPointGain;

    public float currAbilityCoolDown;
    public int totalAbilityCoolDown;

    public float totalScore;
    private float scoreMult;
    private float dashScoreMult;
    private float currMult;

    void Start()
    {
        //Instantiate(player, spawnPoint.position, spawnPoint.rotation);

        GameManager.Instance.player = this;

        playerType = PlayerPrefs.GetString("selectedCharacter");
        DashReady = false;
        abilityGaugeTotal = 100;
        abilityGaugeCurr = 0;
        canGetHit = true;
        totalAbilityCoolDown = 4;
        currAbilityCoolDown = totalAbilityCoolDown;
        Health = 1;
        totalScore = 0;
        scoreMult = 0.01f;
        dashScoreMult = 0.1f;
        currMult = scoreMult;

        if (playerType == "Tank")
        {
            Health = 5;
            playerSprite.sprite = tank;
        }
        else
        {
            Health = 3;
        }

        if (playerType == "Speed")
        {
            Speed = 3;
            abilityPointGain = abilityGaugeTotal * 0.1f;
            playerSprite.sprite = speed;
        }
        else
        {
            Speed = 2;
            abilityPointGain = abilityGaugeTotal * 0.05f;
        }
        if (playerType == "Default")
        {
            playerSprite.sprite = normal;
        }
    }

    void Update()
    {
        if(abilityGaugeCurr >= abilityGaugeTotal)
        {
            abilityGaugeCurr = abilityGaugeTotal;
            DashReady = true;
        }
        if (DashReady == true && GameManager.Instance.hud.isPressed == true)
        {
            GameManager.Instance.hud.dash.gameObject.SetActive(false);
            Dash();
        }
        if(currAbilityCoolDown <= 0)
        {
            GameManager.Instance.spawner.currSpawnSecs = GameManager.Instance.spawner.initSpawnSecs;
            GameManager.Instance.enemy.currSpeed = GameManager.Instance.enemy.initSpeed;
            GameManager.Instance.hud.isPressed = false;
            currAbilityCoolDown = totalAbilityCoolDown;
            currMult = scoreMult;
            DashReady = false;
            canGetHit = true;
        }

        // Addition to the total score
        totalScore += Mathf.Ceil(Time.deltaTime) * currMult;
    }

    public void TakeDamageFromEnemy()
    {
        if(canGetHit == true && GameManager.Instance.hud.isPressed == false)
        {
            Health--;
        }

        if (Health <= 0)
        {
            Health = 0;
            Destroy(gameObject);
            PlayerPrefs.SetFloat("TotalScore", totalScore);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void GetHealth()
    {
        Health++;
    }

    public void GetDashPoints()
    {
        abilityGaugeCurr += abilityPointGain;

        if(abilityGaugeCurr > abilityGaugeTotal)
        {
            abilityGaugeCurr = abilityGaugeTotal;
        }
    }

    public void setHealth(int health)
    {
        Health = health;
    }

    public void setDash(bool isDash)
    {
        DashReady = isDash;
    }

    // should probably be handled in the manager
    public void Dash()
    {
        if (currAbilityCoolDown > 0)
        {
            canGetHit = false;
            currMult = dashScoreMult;
            currAbilityCoolDown -= Time.deltaTime;
            GameManager.Instance.spawner.currSpawnSecs = GameManager.Instance.spawner.dashSpawnSecs;
            GameManager.Instance.enemy.currSpeed = GameManager.Instance.enemy.dashSpeed;
        }
        else
        {
            return;
        }
    }
}
