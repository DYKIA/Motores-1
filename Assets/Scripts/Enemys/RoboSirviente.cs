using UnityEngine;

public class RoboSirviente : EnemyChase // Arraigada Gonzalo
{
    public float moveDistance = 5f;
    private bool movingLeft = true;
    private float leftBoundary;
    private float rightBoundary;

    protected override void Start()
    {
        base.Start();
        leftBoundary = transform.position.x - moveDistance / 2;
        rightBoundary = transform.position.x + moveDistance / 2;
    }

    protected override void Update()
    {
        if (CanSeePlayer())
        {
            Chase();
        }
        else
        {
            MoveLeftRight();
        }
    }

    private void MoveLeftRight() //comportamiento normal
    {
        if (movingLeft)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            if (transform.position.x <= leftBoundary)
            {
                movingLeft = false;
            }
        }
        else
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            if (transform.position.x >= rightBoundary)
            {
                movingLeft = true;
            }
        }
    }

    protected override void Chase()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * Speed * Time.deltaTime);
    }

   
}
