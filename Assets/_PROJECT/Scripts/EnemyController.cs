using StarterAssets;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    public float PatrolTime = 15f;
    public float AggroRange = 10f;
    public float agentSpeed;
    public float agentSpeedModifier = 1.6f;
    public Transform[] Waypoints;

    int _index;
    NavMeshAgent _agent;
    GameObject _player;
    [SerializeField] Image[] Hands;

    private void Awake()
    {
        SetImageActive(false);
        _agent = GetComponent<NavMeshAgent>();
        _index = Random.Range(0, Waypoints.Length);
        _player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Tick", 0, 0.1f);

        if (Waypoints.Length > 0)
        {
            InvokeRepeating("Patrol", 0, PatrolTime);
        }
    }
    private void Patrol()
    {
        _index = _index == Waypoints.Length - 1 ? 0 : _index + 1;
    }
    private void Tick()
    {

        _agent.destination = Waypoints[_index].position;
        _agent.speed = agentSpeed / agentSpeedModifier;

        if (_player != null && Vector3.Distance(transform.position, _player.transform.position) < AggroRange)
        {
            _agent.destination = _player.transform.position;
            _agent.speed = agentSpeed * agentSpeedModifier;
            SetImageActive(true);
        }
        else if (_player != null && Vector3.Distance(transform.position, _player.transform.position) > AggroRange)
        {
            _agent.destination = Waypoints[_index].position;
            _agent.speed = agentSpeed;
            SetImageActive(false);
        }
    }
    void SetImageActive(bool test)
    {
        for (int i = 0; i < Hands.Length; i++)
        {
            Hands[i].enabled = test;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere in the AggroRange
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AggroRange);
    }
}


