using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{
    private GameObject selectedChampion;
    public bool championPlayer;
    RaycastHit hit;
    // Start is called before the first frame update
    void Awake()
    {
        selectedChampion = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if(hit.collider.GetComponent<Targetable>() != null)
                {
                    if(hit.collider.gameObject.GetComponent<Targetable>().targetedEnemyType == Targetable.EnemyType.Minion)
                    {
                        selectedChampion.GetComponent<PlayerCombat>().targetedEnemy = hit.collider.gameObject;

                    }
                } else if(hit.collider.gameObject.GetComponent<Targetable>() == null) {
                    selectedChampion.GetComponent<PlayerCombat>().targetedEnemy = null;
                }
            }
        }
    }
}
