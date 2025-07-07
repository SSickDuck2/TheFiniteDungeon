using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float _attCooldown;
    private float _attCooldownCounter;
    public bool isInRange;
    public KeyCode InteractKey;
    public UnityEvent interactEvent;
    
    
    private void Update()
    {
        {
            if (isInRange && _attCooldownCounter <= 0)
            {
                if (Input.GetKeyDown(InteractKey))
                {
                    interactEvent.Invoke();
                    _attCooldownCounter = _attCooldown;
                }
            }
            else
            {
                _attCooldownCounter -= Time.deltaTime;
            }
        }
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
