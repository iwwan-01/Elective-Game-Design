using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour
{
    public enum EnemyType
    {
        Minion,
        Champion
    }

    public EnemyType targetedEnemyType;
}
