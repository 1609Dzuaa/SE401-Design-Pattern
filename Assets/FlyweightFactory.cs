using System.Collections.Generic;

//Quản lý và cung cấp các flyweight
public class EnemyFlyweightFactory
{
    private Dictionary<string, EnemyFlyweight> flyweights = new Dictionary<string, EnemyFlyweight>();

    public EnemyFlyweight GetFlyweight(string type)
    {
        if (!flyweights.ContainsKey(type))
        {
            switch (type)
            {
                case "EnemyA":
                    flyweights[type] = new EnemyFlyweight("EnemyA", 100, 10, 1.5f);
                    break;
                case "EnemyB":
                    flyweights[type] = new EnemyFlyweight("EnemyB", 200, 20, 1.2f);
                    break;
                case "EnemyC":
                    flyweights[type] = new EnemyFlyweight("EnemyC", 300, 30, 0.8f);
                    break;
            }
        }
        return flyweights[type];
    }
}
