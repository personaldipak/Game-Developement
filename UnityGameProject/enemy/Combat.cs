using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Combat : MonoBehaviour {

    CharacterStats mystats;

    public float attackspeed = 1f;
    private float attackcooldown = 0f;
    public float attackdealy = .6f;

    public event System.Action OnAttack;

    public void Start()
    {
        mystats = GetComponent<CharacterStats>();
    }

    public void Update()
    {
        attackcooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetstats)
    {
        if(attackcooldown <= 0)
        {
            StartCoroutine(DoDamage(targetstats, attackdealy));

            if (OnAttack != null)
                OnAttack();

            attackcooldown = 1f / attackspeed; 
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(mystats.damage.Getvalue());
    }
}
