using UnityEngine;
//TP-Final Sayuri Ganiko
public abstract class EnemyChase : MonoBehaviour 
{
    public float ActualLife;
    public float MaxLife = 100f;
    public float RadiusVision;
    public float Speed;
    public int Damage;

    protected Transform player; // Referencia al jugador

    protected virtual void Start()
    {
        ActualLife = MaxLife;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if (CanSeePlayer())
        {
            Chase();
        }
    }

    protected virtual void Chase()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * Speed * Time.deltaTime);
    }

    protected bool CanSeePlayer()
    {
        if (player == null) return false;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= RadiusVision;
    }


    public virtual void TakeDamage(float damage)
    {
        ActualLife -= damage;
        if (ActualLife <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Jugador>())
        {
            other.GetComponent<Jugador>().TakeDamage(Damage);
            Die();
        }
    }
}