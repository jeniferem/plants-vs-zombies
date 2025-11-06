using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemiData")]
public class EnemyData : BaseCharacterData
{
    public float attackRange = 5f;
    public float timeBetweenAttacks = 2f;
    public float attackDuration = 1f;
    public float speed = 5f;
    public int damage = 10;
    public string enemyName;
}
