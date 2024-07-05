using UnityEngine;
using System.Collections;

public class KamikazeRock : EnemyChase // Arraigada Gonzalo
{
    public float ExplosionRadius = 5f;
    public float ExplosionDamage = 50f;
    public float ExplosionDelay = 2.5f; 

    private bool activated = false;
    private bool isExploding = false;

    protected override void Update()
    {
        if (!activated && CanSeePlayer())
        {
            activated = true;
        }

        if (activated && !isExploding)
        {
            Chase();
        }
    }

    protected override void Chase()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.position) <= ExplosionRadius)
        {
            StartCoroutine(ExplodeAfterDelay());
        }
    }

    private IEnumerator ExplodeAfterDelay()
    {
        Debug.Log("SUICIDIO INMINENTE NOOOOO");
        isExploding = true;
        yield return new WaitForSeconds(ExplosionDelay);
        Explode();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isExploding)
        {
            StartCoroutine(ExplodeAfterDelay());
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius); //detectar cosas dentro del radio :p

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                // collider.GetComponent<Jugador>().TakeDamage(ExplosionDamage);
            }
        }

        Destroy(gameObject);
    }
}
