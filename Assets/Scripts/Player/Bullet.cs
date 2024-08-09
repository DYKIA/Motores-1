using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Transform target;
    public int DeathCD;

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
}
