using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponentInChildren<UnitBase>())
        {
            if (collision.gameObject.GetComponent<UnitPlayer>())
            {
                this.GetComponentInChildren<EnemyStateMachine>().target = collision.gameObject.transform;
                //Debug.Log("Player detected");
            }
                
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<UnitBase>())
        {
            if (collision.gameObject.GetComponent<UnitPlayer>())
            {
                this.GetComponentInChildren<EnemyStateMachine>().target = null;
                //Debug.Log("Player exited");
            }
                
        }
    }
}
