using Assets.Scripts;
using Assets.Scripts.MovementStates;
using UnityEngine;

public class Player : MonoBehaviour
{
    private StateMachine _stateMachine;
    private float _walkSpeed = 10f;
    private float _runSpeed = 20f;

    void Start()
    {
        _stateMachine = new StateMachine();

        _stateMachine.AddState(new IdleState(_stateMachine));
        _stateMachine.AddState(new WalkState(_stateMachine, transform, _walkSpeed));
        _stateMachine.AddState(new RunState(_stateMachine, transform, _runSpeed));

        _stateMachine.SetState<IdleState>();
    }

    void Update()
    {
        _stateMachine.Update();
    }
}
