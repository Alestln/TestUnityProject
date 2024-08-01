using UnityEngine;

namespace Assets.Scripts.MovementStates
{
    public class WalkState : MovementState
    {
        public WalkState(StateMachine stateMachine, Transform transform, float speed)
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
            Debug.Log($"Walk state [UPDATE] with speed: {Speed}");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                StateMachine.SetState<IdleState>();
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StateMachine.SetState<RunState>();
            }

            Move(inputDirection);
        }
    }
}
