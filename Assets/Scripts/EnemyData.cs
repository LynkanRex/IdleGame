using UnityEngine;


[System.Serializable]
[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public string name = "null";
    public float attackTime = 0.6f;
    public float damage = 5f;
    public float health = 100f;
}
