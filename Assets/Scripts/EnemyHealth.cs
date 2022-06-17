using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private Slider enemySlider3D;
    private Stats statsScript;
    
    // Start is called before the first frame update
    void Awake()
    {
        statsScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Stats>();
        enemySlider3D = GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<Slider>();

        enemySlider3D.maxValue = statsScript.maxHealth;
        statsScript.health = statsScript.maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        enemySlider3D.value = statsScript.health;
    }
}
