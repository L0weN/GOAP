using CrashKonijn.Goap.Classes.References;
using UnityEngine;

public class AttackData : CommonData
{
    public static readonly int ATTACK = Animator.StringToHash("Attack");

    [GetComponent]
    public Animator Animator { get; set; }
}
