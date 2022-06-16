using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Slider playerSlider3D;
    private Slider playerSlider2D;

    Stats statsScript;
    // Start is called before the first frame update
    void Awake()
    {
        statsScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        playerSlider3D = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Slider>();

        playerSlider2D = GetComponent<Slider>();

        playerSlider3D.maxValue = statsScript.maxHealth;
        playerSlider2D.maxValue = statsScript.maxHealth;
        statsScript.health = statsScript.maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        playerSlider2D.value = statsScript.health;
        playerSlider3D.value = playerSlider2D.value;
    }
}
