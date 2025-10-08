using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemiData")]
public class EnemyData : ScriptableObject
{
    public float health = 100f;
    public float spedd = 5f;
    public int damage = 10;
    public string enemyName;
    public string attacKAnimation = "Attack";
    public string deathAnimation = "Die";
    public string walkAnimation = "Walk";
    public string hitAnimation = "Hit";
    public string winAnimation = "Win";
    public string idleAnimation = "Idle";
}
