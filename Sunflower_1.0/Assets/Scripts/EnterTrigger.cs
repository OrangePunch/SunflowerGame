using UnityEngine;
using UnityEngine.Events;

public class EnterTrigger : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private UnityEvent<GameObject> _action;

    private void OnTriggerEnter(Collider other)
    {
        if (_action != null && other.gameObject.tag == _tag)
        {
            _action?.Invoke(other.gameObject);
        }
    }
}
