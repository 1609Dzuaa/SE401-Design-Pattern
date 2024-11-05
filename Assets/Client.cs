using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Client sử dụng Flyweight
public class Client : MonoBehaviour
{
    [SerializeField] EnemyFlyweightFactory enemyFactory;
    [SerializeField] int _numsOfEnemy;
    [SerializeField] Enemy _enemyPrefab;

    void Start()
    {
        //Instantiate clone 1 gameobject có sẵn và trả về cái clone đó

        //Crete n enemyA
        for (int i = 0; i < _numsOfEnemy; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            enemy.Init(enemyFactory.GetFlyweight("EnemyA"));
            //enemy.Init("EnemyA", 5, 10, 15f);
        }

        //Crete n enemyB
        for (int i = 0; i < _numsOfEnemy; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            enemy.Init(enemyFactory.GetFlyweight("EnemyB"));
            //enemy.Init("EnemyB", 4, 8, 12f);
        }

        //Crete n enemyC
        for (int i = 0; i < _numsOfEnemy; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            enemy.Init(enemyFactory.GetFlyweight("EnemyC"));
            //enemy.Init("EnemyC", 3, 6, 9f);
        }
    }
}