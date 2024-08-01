using Assets.Scripts;
using Assets.Scripts.MovementStates;
using UnityEngine;

public class RunState : MovementState
{
    public RunState(StateMachine stateMachine, Transform transform, float speed)
        : base(stateMachine, transform, speed) { }

    public override void Enter()
    {
        Debug.Log($"Movement ({GetType().Name}) state [ENTER]");
    }

    public override void Exit()
    {
        Debug.Log($"Movement ({GetType().Name}) state [EXIT]");
    }

    public override void Update()
    {
        Debug.Log($"Run state [UPDATE] with speed: {Speed}");

        var inputDirection = ReadInput();

        if (inputDirection.sqrMagnitude == 0f)
        {
            StateMachine.SetState<IdleState>();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StateMachine.SetState<WalkState>();
        }

        Move(inputDirection);
    }
}