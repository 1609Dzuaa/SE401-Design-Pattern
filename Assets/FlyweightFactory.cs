using System.Collections.Generic;
using DemoFlyweightPattern;
using UnityEngine;

//Quản lý và cung cấp các flyweight
public class EnemyFlyweightFactory : MonoBehaviour
{
    [SerializeField] EnemyData[] _enemyDatas;
    private Dictionary<string, EnemyFlyweight> flyweights = new Dictionary<string, EnemyFlyweight>();

    private void Awake()
    {
        foreach (var data in _enemyDatas)
            if (!flyweights.ContainsKey(data.EnemyName))
                flyweights.Add(data.EnemyName, data.Flyweight);
    }

    public EnemyFlyweight GetFlyweight(string type)
    {
        return flyweights[type];
    }
}

[System.Serializable]
public class EnemyData
{
    public string EnemyName;
    public EnemyFlyweight Flyweight;
}