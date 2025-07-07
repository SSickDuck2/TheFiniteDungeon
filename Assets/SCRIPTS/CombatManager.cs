using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;
    
    public bool CanReceiveInput;
    public bool InputReceived;

    public Transform attackOrigin;
    public float attackRadius = 1f;
    public LayerMask _enemy;
    void Awake()
    {
        instance = this;
        //Debug.Log("CombatManager initialized");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        InputManager();
        if (CanReceiveInput)
        {
            InputReceived = true;
            CanReceiveInput = false;
        }
        else
        {
            return;
        }
    }

    public void InputManager()
    {
        if (!CanReceiveInput)
        {
            CanReceiveInput = true;
        }
        else
        {
            CanReceiveInput = false;
        }
    }
}
