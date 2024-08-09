using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    public bool isDead;

    [SerializeField]
    public HealthComponent HP;

    [SerializeField]
    public GameObject[] gunArray;

    public float speed;

    public PolygonCollider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        hitbox = this.gameObject.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HP.currHP <= 0)
        {
            Debug.Log("Dead");
            UnitDeath();
        }
    }

    virtual protected void UnitDeath()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<AmmoBase>())
        {
            if (collision.IsTouching(hitbox))
            {
                HP.TakeDamage(collision.gameObject.GetComponentInChildren<AmmoBase>().damage);
                Destroy(collision.gameObject);
            }
        }

    }
}
