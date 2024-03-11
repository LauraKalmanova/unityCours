using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    public Dictionary<StateEnum, IState> States { get; private set; } = new Dictionary<StateEnum, IState>();

    private StateEnum state;

    public StateManager(GameObject target, ExampleScriptableObject data, IInputController inputController)
    {
        States.Add(StateEnum.Idle, new IdleState(target));
        States.Add(StateEnum.Moving, new MoveState(target, inputController, data));
    }

    public void ChangeState(StateEnum newState)
    {
        if(States.ContainsKey(state))
        {
            States[state].Exit();
        }
        state = newState;
        if (States.ContainsKey(state))
        {
            States[state].Begin();
        }
    }

    public void Update()
    {
        if(state != StateEnum.Idle && inputController.IsIdle)
        {
            ChangeState(StateEnum.Idle);
        } 
        else if (inputController.MoveDirection != 0)
        {
            ChangeState(StateEnum.Moving);
        }
        

        States[state].Update();
    }
}