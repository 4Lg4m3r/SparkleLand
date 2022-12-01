using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 1f;
    public float minDist = 1f;
    public Transform target;

    [SerializeField] float health, maxHealth = 3f;

    void Start()
    {
        // if no target specified, assume the player
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
        health = maxHealth;
    }

    void Update()
    {
        if (target == null)
            return;
        // face the target
        transform.LookAt(target);
        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, target.position);
        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if (distance > minDist)
            transform.position += transform.forward * speed * Time.deltaTime;
    }
    
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health player = other.transform.GetComponent<Health>();

            if (player != null)
            {
                player.Damaged();
            }
                                   
        }
    }
}