using UnityEngine;

public class AttakState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        manager.SetSpeed(0);
    }

    public override void ExitState(EnemyStateManager manager)
    {
        // Exit state logic here
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        Debug.Log("Ataka!");

        if (manager.DistanceToTarget() >= manager.attakDistanse)
        {
            manager.SwitchState(manager.argrState);
            return;
        }
    }
}
