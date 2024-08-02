using UnityEngine;

namespace Assets.Scripts.MovementStates
{
    public abstract class MovementState : State
    {
        protected readonly Transform Transform;
        protected readonly float Speed;
        protected Vector2 Velocity;

        public MovementState(StateMachine stateMachine, Transform transform, float speed) : base(stateMachine)
        {
            Transform = transform;
            Speed = speed;
        }

        protected Vector2 ReadInput()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            return new Vector2(horizontalInput, verticalInput).normalized;
        }

        protected void Move(Vector2 inputDirection)
        {
            Vector3 move = Speed * Time.deltaTime * (Vector3)inputDirection;
            Transform.Translate(move, Space.World);
        }
    }
}
