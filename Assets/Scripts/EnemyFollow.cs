using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform Player;
    UnityEngine.AI.NavMeshAgent agent;

    [SerializeField] float health, maxHealth = 3f;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {

        agent.destination = Player.position;
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