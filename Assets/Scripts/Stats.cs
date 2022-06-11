using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float attackDamage;
    public float attackSpeed;
    public float attackTime;

    PlayerCombat combatScript;

    // Start is called before the first frame update
    void Awake()
    {
        combatScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            combatScript.targetedEnemy = null;
            combatScript.performMeleeAttack = false;
        }
    }
}
