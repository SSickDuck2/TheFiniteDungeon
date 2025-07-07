using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Info")] [SerializeField]
    private float _jumpforce = 5;
    [SerializeField] private float _speed = 5;
    Vector3 direction;
    
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private bool isDead = false;

    [Header("Collision Info")] [SerializeField]
    private bool _isGrounded;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float radius;
    private Rigidbody2D _rb;
    private Collider2D _col;
    
    [Header("Attack Info")]
    public LayerMask _Enemies;
    public GameObject attackPoint;
    public int damage = 50;
    public float cooldownTime = 0.5f;
    private float cooldownTimer = 0f;
    
    Animator _animator;
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
        _col = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollision();
        Animation();
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
            Move();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
            Move();
        }
        // else if (Input.GetKeyUp(KeyCode.None))
        // {
        //     _rb.velocity =  new Vector2(0, _rb.velocity.y);
        // }
        
        // _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rb.velocity.y);
        
        //jumping part
        if (_isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0f)
        {
            direction = Vector3.up;
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpforce);
            SoundManager.instance.PlaySound3D("Jump", transform.position);
        }

        if (Input.GetKeyUp(KeyCode.Space) && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0;
        }
        
        //Attacking part
        if (cooldownTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                CombatManager.instance.Attack();
                cooldownTimer = cooldownTime;
            }
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
        
        //Dead
        if (!isDead && GetComponent<HealthManager>().currentHealth <= 0)
        {
            StartCoroutine(Death());
        }

        if (Input.GetKey(KeyCode.P))
        {
            InstaDeath();
        }
    }

    void AtkENM()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, _Enemies);
        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<HealthManager>().TakeDamage(damage);
        }
        SoundManager.instance.PlaySound3D("Hit", transform.position);
    }

    void Move()
    {
        if (_rb.velocity.x < 0)
        {
            transform.localScale = new Vector3((float)-0.5, (float)0.5, (float)0.5);
        }
        else
        {
            transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.5);
        }

        _rb.velocity = new Vector2(direction.x * _speed, _rb.velocity.y);
    }


    void Animation()
    {
        if (_rb.velocity.x > 1f || _rb.velocity.x < -1f)
        {
            _animator.SetBool("RUN", true);
            _animator.SetBool("JUMP", false);
        }
        else
        {
            _animator.SetBool("RUN", false);
        }

        if (_rb.velocity.y > 0 || _rb.velocity.y < 0)
        {
            _animator.SetBool("JUMP", true);
            _animator.SetBool("RUN", false);
        }
        else
        {
            _animator.SetBool("JUMP", false);
        }
}

    void CheckCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, _groundLayer);
        if (hit.collider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
        //Debug.DrawRay(transform.position, Vector2.down * 0.7f, Color.red);
    }
    
    public void InstaDeath()
    {
        if (!isDead)
        {
            GetComponent<HealthManager>().currentHealth = 0;
        }
    }
    
    IEnumerator Death()
    {
        if (isDead) yield break; // tránh gọi lặp lại nhiều lần
        isDead = true;
        _animator.SetTrigger("DEATH");
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length); // đợi animation
        //gameObject.GetComponent<PauseMenu>().PauseGame();
    }

    // public void Respawn()
    // {
    //     Debug.Log("Respawn");
    //     SceneController.instance.RestartLevel();
    // }
    
    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireSphere(transform.position, radius);
    // }
}
