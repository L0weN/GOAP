using UnityEngine;

[CreateAssetMenu(fileName = "Attack Config", menuName = "AI/Attack Config", order = 1)]
public class AttackConfigSO : ScriptableObject
{
    public float SensorRadius = 10f;
    public float MeleeAttackRadius = 1f;
    public int MeleeAttackCost = 1;
    public float AttackDelay = 1f;
    public LayerMask AttackableLayerMask;
}
