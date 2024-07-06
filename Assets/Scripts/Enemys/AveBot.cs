using UnityEngine;

public class AveBot : EnemyChase // Arraigada Gonzalo
{
    public float diveSpeed = 10f;
    public float flightRangeX = 5f;
    public float flightRangeY = 3f;

    private Vector3 initialPosition;
    private bool diving = false;
    private Vector3 diveTarget;

    protected override void Start()
    {
        base.Start();
        initialPosition = transform.position;
    }

    protected override void Update()
    {
        if (!diving)
        {
            if (CanSeePlayer())
            {
                diving = true;
                diveTarget = player.position;
            }
            else
            {
                FlyRandomly();
            }
        }
        else
        {
            Dive();
        }
    }

    private void FlyRandomly()
    {
        float newX = initialPosition.x + Mathf.PingPong(Time.time * Speed, flightRangeX) - flightRangeX / 2;
        float newY = initialPosition.y + Mathf.PingPong(Time.time * Speed, flightRangeY) - flightRangeY / 2;
        float newZ = initialPosition.z + Mathf.PingPong(Time.time * Speed, flightRangeX) - flightRangeX / 2; 
        transform.position = new Vector3(newX, newY, newZ);
    }


    private void Dive()
    {
        Vector3 direction = (diveTarget - transform.position).normalized;
        transform.position += direction * diveSpeed * Time.deltaTime;

        if (transform.position.y <= diveTarget.y || transform.position.y <= 0)
        {
            Die();
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerFeet") || other.CompareTag("Ground"))
        {
            Die();
        }
      
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
