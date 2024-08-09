using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitPlayer : UnitBase
{
    private void Start()
    {
        GameManager.Instance.player = this;
    }

    protected override void UnitDeath()
    {
        isDead = true;
        // should put this in manager instead
        SceneManager.LoadScene("GameOver");
    }
}
