using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float attackRange = 1f;
    public float AttackDamage = 10f;
    public float runSpeed = 2f;
    public float attackDuration = 1f;
    public float attackCooldown = 1f;
    public string attackSoundName = "ZombieAttack";
    public string PrimaryTargetTag = "Tower";
    public string runAnimationName = "zombieRun";
    public string attackAnimationName = "ZombieAttack";
    public string dieAnimationName = "ZombieDie";
    public string winAnimationName = "ZombieWin";

    public string dieSoundName = "EnemyDie";
}
