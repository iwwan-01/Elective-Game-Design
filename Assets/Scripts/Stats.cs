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
    KillCounter killCounter;

    // Start is called before the first frame update
    void Awake()
    {
        combatScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        killCounter = GameObject.Find("Kill Counter Canvas 2D").GetComponentInChildren<KillCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if(gameObject.tag == "Enemy")
            {
                killCounter.killAmount++;
            }
            Destroy(gameObject);
            combatScript.targetedEnemy = null;
            combatScript.performMeleeAttack = false;
        }
    }
}
