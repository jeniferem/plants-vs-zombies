using UnityEngine;

[System.Serializable]
public class EnemyAssets
{
    public EnemyType enemyType;
    public InstantiatepoolObjects enemypool;
}
[System.Serializable]
public class InstantiateEnemy
{
    public float spawnTime;
    public EnemyType enemyType;
    public int LaneIndex;
}
public enum EnemyType
{
    Basic,
    Strong,
}
