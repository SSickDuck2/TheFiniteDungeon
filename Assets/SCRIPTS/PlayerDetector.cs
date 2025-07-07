using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _attCooldown;
    private float _attCooldownCounter;
    public bool isInRange;
    public UnityEvent interactEvent;
    

private void Update()
    {
        // if (isInRange)
        // {
        //          interactEvent.Invoke();
        //         _attCooldownCounter = _attCooldown;
        // }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
