using UnityEngine;

public class MoveState : BaseState
{
    private readonly GameObject target;
    private readonly ExampleScriptableObject data;
    private readonly IInputController inputController;

    public MoveState(GameObject target, IInputController inputController, ExampleScriptableObject data) 
    {
        this.target = target;
        this.inputController = inputController;
        this.data = data;
    }

    public override void Update()
    {
        target.transform.position += inputController.MoveDirection * data.Direction * data.Speed * Time.deltaTime;
        
    }
}
