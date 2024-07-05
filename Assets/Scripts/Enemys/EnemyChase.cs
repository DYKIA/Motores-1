using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyChase : MonoBehaviour
{
    public float ActualLife;
    public float MaxLife;
    public float RadiousVision;
    public float Speed;
    public float Damage;
    public float Distance;
    //  public Jugador Jugador;

    public virtual void TakeDamage(float damage)
    {

    }

    public virtual void Chase()
    {

    }
}
