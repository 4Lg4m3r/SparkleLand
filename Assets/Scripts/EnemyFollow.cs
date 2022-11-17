using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform Player;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    
    void Update()
    {

        agent.destination = Player.position;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.transform.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.Damage();
                Destroy(Player.gameObject);
            }
        }
    }
}