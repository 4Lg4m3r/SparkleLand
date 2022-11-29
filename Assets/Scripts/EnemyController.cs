using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

    public void die()
    {

        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }
    }

}