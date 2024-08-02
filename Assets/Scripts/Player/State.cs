namespace Assets.Scripts.MovementStates
{
    public abstract class State
    {
        protected readonly StateMachine StateMachine;

        public State(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
    }
}
