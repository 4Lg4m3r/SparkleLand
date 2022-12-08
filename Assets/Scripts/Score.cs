using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject ScroreText;
    public int theScore;
    
    void OnTriggerEnter(Collider other)
    {
        theScore += 1;
        Destroy(gameObject);
    }
}
