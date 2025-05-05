using UnityEngine;

public class ArgrState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("Enter agr");
        manager.SetSpeed(manager.walkSpeed);
    }

    public override void ExitState(EnemyStateManager manager)
    {
        // Exit state logic here
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.DistanceToTarget() >= manager.agroDistanse ) 
        {
            manager.SwitchState(manager.idleState);
            return;
        }

        if (manager.DistanceToTarget() <= manager.attakDistanse)
        {
            manager.SwitchState(manager.attakState);
            return;
        }

    }   
}