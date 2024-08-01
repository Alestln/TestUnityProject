using UnityEngine;

namespace Assets.Scripts.MovementStates
{
    public abstract class MovementState : State
    {
        protected readonly Transform Transform;
        protected readonly float Speed;

        public MovementState(StateMachine stateMachine, Transform transform, float speed) : base(stateMachine)
        {
            Transform = transform;
            Speed = speed;
        }

        protected Vector2 ReadInput()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            return new Vector2(horizontalInput, verticalInput).normalized;
        }

        protected void Move(Vector2 inputDirection)
        {
            Transform.position += new Vector3(inputDirection.x, inputDirection.y, 0f) * (Speed * Time.deltaTime);
        }
    }
}
