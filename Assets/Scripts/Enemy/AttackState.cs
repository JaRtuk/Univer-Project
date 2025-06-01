using UnityEngine;
using System;

public class AttakState : BaseState
{
    [SerializeField] private Transform weapon;
    private System.Random rnd;

    public override void EnterState(EnemyStateManager manager)
    {
        // weapon = manager.transform.Find("Katana_LODB_game");

        weapon.localRotation = Quaternion.Euler(74.714f, -124.856f, 320.846f);
        weapon.localPosition = new Vector3(-0.0099f, 0.0847f, 0.0171f);

        rnd = new System.Random();

        bool TypeAttack = Convert.ToBoolean(rnd.Next(0, 2));
        manager.SetSpeed(0);
        manager.animator.SetBool("IsAttack", true);
        manager.animator.SetBool("TypeAttack", TypeAttack);
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        // if (weapon == null)
        // {
        //     weapon = manager.transform.Find("Katana_LODB_game");
        // }
    }

    public override void ExitState(EnemyStateManager manager)
    {
    }

}
