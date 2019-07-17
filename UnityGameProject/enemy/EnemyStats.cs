using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public GameObject potions;
    public GameObject coins;
    public GameObject teleport;

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        teleport.SetActive(true);
    }

    void OnDestroy()
    {
        if(Random.value <= 0.5)
        {
            Instantiate(potions, transform.position, transform.rotation);
        }

        if(Random.value <= 0.3)
        {
            Instantiate(coins, transform.position, transform.rotation);
        }
    }
}
