using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField] private bool _rotateObject;

    private NavMeshAgent _navMeshAgent;
    private GameObject _target;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (_navMeshAgent == null)
        {
            Debug.Log("attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    private void LateUpdate()
    {
        if (_rotateObject)
        {
            transform.rotation = Quaternion.LookRotation(-_navMeshAgent.velocity.normalized);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(_navMeshAgent.velocity.normalized);
        }
    }

    private void SetDestination()
    {
        if (_target != null)
        {
            Vector3 targetVector = _target.gameObject.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}
