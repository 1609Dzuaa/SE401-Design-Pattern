using System.Collections.Generic;
using UnityEngine;

//Trong Unity, Một lớp phải kế thừa từ MonoBehavior nếu nó muốn được gán cho GameObject
public class Enemy : MonoBehaviour
{
    #region Flyweight Reference
    public EnemyFlyweight flyweight;
    #endregion

    /*private string Name;
    private int Health;
    private int Damage;
    private float MoveSpeed;*/

    #region Init Flyweight
    public void Init(EnemyFlyweight flyweight)
    {
        this.flyweight = flyweight;
        Debug.Log("Enemy " + flyweight.Name + " with Health, Damage, Speed of: " 
            + flyweight.Health + ", " + flyweight.Damage + ", " + flyweight.MoveSpeed);
    }
    #endregion

    #region Init Normal
    /*public void Init(string name, int health, int damage, float moveSpeed)
    {
        this.Name = name;
        this.Health = health;
        this.Damage = damage;
        this.MoveSpeed = moveSpeed;
        Debug.Log("Enemy " + Name + " with Health, Damage, Speed of: "
           + Health + ", " + Damage + ", " + MoveSpeed);
    }*/
    #endregion
}