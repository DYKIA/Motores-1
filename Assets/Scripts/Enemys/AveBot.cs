using UnityEngine;

public class AveBot : EnemyChase // Arraigada Gonzalo
{
    public float diveSpeed = 10f;

    private bool diving = false;

    protected override void Update()
    {
        if (CanSeePlayer() && !diving)
        {
            diving = true;
            Dive();
        }

        if (diving)
        {
            ContinueDive();
        }
    }

    private void Dive() // movimiento de lanzarse sobre el jugador
    {       
        Vector3 direction = (player.position - transform.position).normalized;
        GetComponent<Rigidbody>().velocity = direction * diveSpeed;
    }

    private void ContinueDive() // ir hacia el jugador
    {
        Vector3 direction = (player.position - transform.position).normalized;
        GetComponent<Rigidbody>().velocity = direction * diveSpeed;
    }

    protected override void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag("PlayerFeet")) //supuesto pie del jugador
        {
            Die();
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
