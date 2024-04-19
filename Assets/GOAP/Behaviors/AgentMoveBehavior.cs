using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent),typeof(Animator))]
public class AgentMoveBehavior : MonoBehaviour
{
    private NavMeshAgent NavMeshAgent;
    private Animator Animator;
    private AgentBehaviour AgentBehaviour;

    private ITarget CurrentTarget;

    [SerializeField] private float MinMoveDistance = 0.25f;
    private Vector3 LastPosition;

    private static readonly int WALK = Animator.StringToHash("Walk");

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
        AgentBehaviour = GetComponent<AgentBehaviour>();
    }

    private void OnEnable()
    {
        AgentBehaviour.Events.OnTargetInRange += EventsOnTargetInRange;
        AgentBehaviour.Events.OnTargetChanged += EventsOnTargetChanged;
        AgentBehaviour.Events.OnTargetOutOfRange += EventsOnTargetOutOfRange;
    }

    private void OnDisable()
    {
        AgentBehaviour.Events.OnTargetInRange -= EventsOnTargetInRange;
        AgentBehaviour.Events.OnTargetChanged -= EventsOnTargetChanged;
        AgentBehaviour.Events.OnTargetOutOfRange -= EventsOnTargetOutOfRange;
    }

    private void EventsOnTargetInRange(ITarget target)
    {
        CurrentTarget = target;
    }

    private void EventsOnTargetChanged(ITarget target, bool inRange)
    {
        CurrentTarget = target;
        LastPosition = CurrentTarget.Position;
        NavMeshAgent.SetDestination(target.Position);
        Animator.SetBool(WALK, true);
    }

    private void EventsOnTargetOutOfRange(CrashKonijn.Goap.Interfaces.ITarget target)
    {
        Animator.SetBool(WALK, false);
    }

    private void Update()
    {
        if (CurrentTarget == null) return;

        if (MinMoveDistance <= Vector3.Distance(CurrentTarget.Position, LastPosition))
        {
            LastPosition = CurrentTarget.Position;
            NavMeshAgent.SetDestination(CurrentTarget.Position);
        }
        
        Animator.SetBool(WALK, NavMeshAgent.velocity.magnitude > 0.1f);
    }
}
