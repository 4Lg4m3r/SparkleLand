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

    bool isImmune;
    public GameObject player;
    public GameObject enemy;
    public float immunityTime;
    public float immunityDuration;

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

        /*if (isImmune == false && enemy.isTouching(player))
        {
            Damaged();
            isImmune = true;
            immunityTime = 2;
        }
        else if (isImmune == true)
        {
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                isImmune = false;
            }
        }*/


        if (health <= 0)
        {
            Debug.Log("Death");
            pauseGame();

            // if death = go to game over scene
            //Destroy(this.gameObject);
            //if destroy object, it will give you errors
        }


    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

   

    public void Damaged()
    {
        health -= 1;
        // this will remove the whole hearts, not just empty them
        /*if (health < numOfHearts)
        {
            numOfHearts = health;
        }*/

    }

}