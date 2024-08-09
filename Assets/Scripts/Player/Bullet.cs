using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Transform target;
    public int DeathCD;
    public EnemyChase enemy;

    void Start()
    {
        FindClosestEnemy();
        StartCoroutine(CooldownRoutine());
        
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void FindClosestEnemy()
    {
        EnemyChase[] enemies = FindObjectsOfType<EnemyChase>(); // Encuentra todos los objetos que heredan de EnemyChase
        float closestDistance = Mathf.Infinity;

        foreach (EnemyChase enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                target = enemy.transform;
            }
        }
    }
    protected IEnumerator CooldownRoutine()
    { 
        yield return new WaitForSeconds(DeathCD);
        Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyChase enemy = other.gameObject.GetComponent<EnemyChase>();
        if (enemy != null)
        {
            Debug.Log("bala mando da�o");
            float damage = 20;
            enemy.TakeDamage(damage);
        }
        else
        {
            Debug.Log("no colisiona con enemigo");
            Destroy(this.gameObject);
        }
    }
}
