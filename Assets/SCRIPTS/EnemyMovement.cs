using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Info")] private Rigidbody2D _rb;
    public LayerMask _layerMask;
    public float _speed;
    public int _direction;
    private Animator _animator;
    private Vector2 movement;
    [SerializeField] private float rayRange;

    [Header("Attack Info")] public LayerMask _Enemies;
    public GameObject attackPoint;
    public int damage;
    [SerializeField] private float radius;
    [SerializeField] Collider2D _PlayerDetect;

    public bool isInRange;
    private bool isAttack = false;
    private bool isDead = false;
    void Start()
    {
        isInRange = false;
        _rb = GetComponent<Rigidbody2D>();
        _direction = 1;
        _animator = GetComponent<Animator>();
        _animator.SetBool("RUN", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckCollision();
        Move();
        if (GetComponent<HealthManager>().currentHealth <= 0)
        {
            StartCoroutine(Death());
        }
        
        if (isInRange == true)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            StartCoroutine(attack());
        }
    }

    void Move()
    {

        movement.x = _direction * _speed;
        movement.y = _rb.velocity.y;
        _rb.velocity = movement;
        if (_rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    IEnumerator attack()
    {
        if (isAttack) yield break;
        isAttack = true;
        
        _animator.SetTrigger("ATTACK");
        
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length); // đợi animation + delay

        isAttack = false;
    }
    
    void AtkPlayer()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, _Enemies);
        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<HealthManager>().TakeDamage(damage);
            SoundManager.instance.PlaySound3D("MonsterHit", transform.position);
        }

    }

    void CheckCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rayRange, _layerMask);
        if (hit.collider != null)
        {
            _direction *= -1;
        }

        RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, rayRange, _layerMask);
        if (hitL.collider != null)
        {
            _direction *= -1;
        }
    }

    IEnumerator Death()
    {
        if (isDead) yield break; // tránh gọi lặp lại nhiều lần
        isDead = true;
        _animator.SetTrigger("DEATH");
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length); // đợi animation
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            _animator.SetBool("isInRange", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            _animator.SetBool("isInRange", false);
            isAttack = false; //Thêm dòng này để cho phép tấn công lại sau
            _animator.ResetTrigger("ATTACK"); //reset trigger để tránh bị kẹt animation
        }
    }
    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    // }
}
