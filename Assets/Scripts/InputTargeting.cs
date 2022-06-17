using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{
    private GameObject selectedChampion;
    private bool championPlayer;
    private RangeIndicator rangeIndicator;
    RaycastHit hit;
    // Start is called before the first frame update
    void Awake()
    {
        selectedChampion = GameObject.FindGameObjectWithTag("Player");
        rangeIndicator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<RangeIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) || rangeIndicator.isVisible && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if(hit.collider.GetComponent<Targetable>() != null)
                {
                    if(hit.collider.gameObject.GetComponent<Targetable>().targetedEnemyType == Targetable.EnemyType.Minion)
                    {
                        selectedChampion.GetComponent<PlayerCombat>().targetedEnemy = hit.collider.gameObject;
                        rangeIndicator.rangeIndicatorImage.enabled = false;
                        rangeIndicator.isVisible = false;
                    }

                } else if(hit.collider.gameObject.GetComponent<Targetable>() == null) {
                    selectedChampion.GetComponent<PlayerCombat>().targetedEnemy = null;
                }
            }
        }
    }
}
