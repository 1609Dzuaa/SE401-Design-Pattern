using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flyweight chứa các thuộc tính chung
public class EnemyFlyweight
{
    public string Name;
    public int Health;
    public int Damage;
    public float MoveSpeed;

    public EnemyFlyweight(string name, int health, int damage, float moveSpeed)
    {
        Name = name;
        Health = health;
        Damage = damage;
        MoveSpeed = moveSpeed;
    }
}
