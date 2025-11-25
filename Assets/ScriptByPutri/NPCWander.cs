using UnityEngine;
using UnityEngine.AI;

public class NPCWander : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator; // <--- TAMBAHKAN INI
    public float range = 10.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // <--- TAMBAHKAN INI
        PergiKeTitikBaru();
    }

    void Update()
    {
        // Mendapatkan kecepatan horizontal agent
        Vector3 localVelocity = transform.InverseTransformDirection(agent.velocity);
        float speed = localVelocity.z; // Kecepatan maju/mundur

        // Mengatur parameter "Speed" di Animator
        animator.SetFloat("Speed", speed); // <--- TAMBAHKAN INI

        // Jika NPC sudah sampai di tujuan (atau dekat sekali)
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            PergiKeTitikBaru();
        }
    }

    void PergiKeTitikBaru()
    {
        Vector3 point;
        if (RandomPoint(transform.position, range, out point))
        {
            agent.SetDestination(point);
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}