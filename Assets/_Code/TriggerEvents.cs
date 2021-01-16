using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    [SerializeField] private string tag = "Player";
    [SerializeField] private UnityEvent triggerEnter;
    [SerializeField] private UnityEvent triggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(tag)) return;
        triggerEnter?.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(tag)) return;
        triggerExit?.Invoke();
    }
}
