using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemoFlyweightPattern
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyFlyweight", order = 1)]
    //Flyweight chứa các thuộc tính chung
    public class EnemyFlyweight : ScriptableObject
    {
        public string Name;
        public int Health;
        public int Damage;
        public float MoveSpeed;
    }
}
