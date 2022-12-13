using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Mush : MonoBehaviour
{
    public int mushValue = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(mushValue);
        }

        Destroy(gameObject);
    }
}
