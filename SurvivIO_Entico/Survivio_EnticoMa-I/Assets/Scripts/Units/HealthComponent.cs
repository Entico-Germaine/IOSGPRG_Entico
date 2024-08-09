using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    public int maxHP;
    public int currHP;

    [SerializeField]
    public HealthBarFloating HPbar;

    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;

        HPbar = this.GetComponentInChildren<HealthBarFloating>();
        HPbar.UpdateHP(currHP, maxHP);
    }

    private void Update()
    {
        if(currHP <= 0)
        {
            zeroHealth();
        }
    }

    public void TakeDamage(int damage)
    {
        currHP -= damage;
        HPbar.UpdateHP(currHP, maxHP);
    }
    
    private void zeroHealth()
    {
        currHP = 0;
    }

    public int GetHP()
    {
        return currHP;
    }
}
