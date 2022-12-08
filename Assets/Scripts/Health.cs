using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Image heart;
    public Image heart1;
    public Image heart2;

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            
        }


        if (health <= 0)
        {
            Debug.Log("Death");
            Destroy(gameObject);
        }


    }

   

    public void Damaged()
    {
        health -= 1;
        if (health < numOfHearts)
        {
            numOfHearts = health;
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Destroy(heart2);
        }

        if (health == 2)
        {
            Destroy(heart);
        }

        if (health == 1)
        {
            Destroy(heart1.gameObject);
        }
    }

}