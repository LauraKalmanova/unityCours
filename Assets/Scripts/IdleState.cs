using UnityEngine;

public class IdleState : BaseState
{
    private readonly GameObject target;
    private float height;

    public IdleState(GameObject target)
    {
        this.target = target;
    }

    public override void Begin()
    {
        height = target.transform.position.y;
    }

    public override void Update()
    {
        var pos = target.transform.position;
        target.transform.position = new Vector3(pos.x, height + Mathf.Cos(Time.time), pos.z);
    }
    public override void Exit()
    {
        var pos = target.transform.position;
        target.transform.position = new Vector3(pos.x, height, pos.z);
    }
}
