using System.Collections.Generic;
using UnityEngine;
using DemoFlyweightPattern;

//Trong Unity, Một lớp phải kế thừa từ MonoBehavior nếu nó muốn được gán cho GameObject
public class Enemy : MonoBehaviour
{
    #region Flyweight Reference
    [HideInInspector] public EnemyFlyweight Flyweight;
    #endregion

    private string Name;
    private int Health;
    private int Damage;
    private float MoveSpeed;

    #region Init Flyweight
    public void Init(EnemyFlyweight flyweight)
    {
        this.Flyweight = flyweight;
        Debug.Log(Flyweight.Name + " with Health, Damage, Speed of: " 
            + Flyweight.Health + ", " + Flyweight.Damage + ", " + Flyweight.MoveSpeed);
    }
    #endregion

    #region Init Normal
    /*public void Init(string name, int health, int damage, float moveSpeed)
    {
        this.Name = name;
        this.Health = health;
        this.Damage = damage;
        this.MoveSpeed = moveSpeed;
        Debug.Log(Name + " with Health, Damage, Speed of: "
           + Health + ", " + Damage + ", " + MoveSpeed);
    }*/
    #endregion
}