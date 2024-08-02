using UnityEngine;

namespace Assets.Scripts.MovementStates
{
    public class IdleState : State
    {
        public IdleState(StateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            Debug.Log("Idle state [ENTER]");
        }

        public override void Exit()
        {
            Debug.Log("Idle state [EXIT]");
        }

        public override void Update()
        {
            Debug.Log("Idle state [UPDATE]");

            if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    StateMachine.SetState<RunState>();
                }
                else
                {
                    StateMachine.SetState<WalkState>();
                }
            }
        }
    }
}
