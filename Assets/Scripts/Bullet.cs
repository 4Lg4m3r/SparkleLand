using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifeDuration = 2f;
    public float speed = 8f;
    private float lifeTimer;


    // Use this for initialization
    void Start()
    {
        lifeTimer = lifeDuration;
    }
    // Update is called once per frame
    void Update()
    {
        // Make the bullet move
        transform.position += transform.forward * speed * Time.deltaTime;
        
        // Check if the bullet should be destroyed
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
