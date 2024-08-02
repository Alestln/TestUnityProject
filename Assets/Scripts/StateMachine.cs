using Assets.Scripts.MovementStates;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class StateMachine
    {
        private State CurrentState;

        Dictionary<Type, State> _states = new Dictionary<Type, State>();

        public void AddState(State state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SetState<T>() where T : State
        {
            var type = typeof(T);

            if (CurrentState is not null && CurrentState.GetType() == type)
            {
                return;
            }

            if (_states.TryGetValue(type, out var newState))
            {
                CurrentState?.Exit();
                CurrentState = newState;
                CurrentState.Enter();
            }
            else
            {
                Debug.LogError($"State of type {type} not found in StateMachine.");
            }
        }

        public void Update()
        {
            CurrentState.Update();
        }
    }
}
