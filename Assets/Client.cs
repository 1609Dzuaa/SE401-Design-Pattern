using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Client sử dụng Flyweight
public class Client : MonoBehaviour
{
    private EnemyFlyweightFactory enemyFactory;
    [SerializeField] int _numsOfEnemy;
    [SerializeField] Enemy _enemyPrefab;

    void Start()
    {
        enemyFactory = new EnemyFlyweightFactory();
        //Instantiate clone 1 gameobject có sẵn và trả về cái clone đó

        //Crete n enemyA
        for (int i = 0; i < _numsOfEnemy; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            enemy.Init(enemyFactory.GetFlyweight("EnemyA"));
            //enemy.Init("EnemyA", 100, 10, 1.5f);
        }

        //Crete n enemyB
        for (int i = 0; i < _numsOfEnemy; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            enemy.Init(enemyFactory.GetFlyweight("EnemyB"));
            //enemy.Init("EnemyB", 200, 20, 1.2f);
        }

        //Crete n enemyC
        for (int i = 0; i < _numsOfEnemy; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            enemy.Init(enemyFactory.GetFlyweight("EnemyC"));
            //enemy.Init("EnemyC", 300, 30, 0.8f);
        }
    }
}