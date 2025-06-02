using UnityEngine;
using System;
using System.Collections;

public class AttakState : BaseState
{
    [SerializeField] private Transform weapon;
    [SerializeField] private EnemyWeaponDamager damager; // Ссылка на Damager
    private System.Random rnd;

    public override void EnterState(EnemyStateManager manager)
    {
        weapon.localRotation = Quaternion.Euler(74.714f, -124.856f, 320.846f);
        weapon.localPosition = new Vector3(-0.0099f, 0.0847f, 0.0171f);

        rnd = new System.Random();
        bool TypeAttack = Convert.ToBoolean(rnd.Next(0, 2));
        
        manager.SetSpeed(0);
        manager.animator.SetBool("IsAttack", true);
        manager.animator.SetBool("TypeAttack", TypeAttack);

        // Активация урона при входе в состояние
        if (damager != null) 
        {
            damager.EnableDamage();
        }
    }

    public override void ExitState(EnemyStateManager manager)
    {
        manager.animator.SetBool("IsAttack", false);

        // Деактивация урона при выходе
        if (damager != null)
        {
            damager.DisableDamage();
        }
    }

    // UpdateState остаётся без изменений
    public override void UpdateState(EnemyStateManager manager) 
    {
        manager.SetSpeed(0);
    }
}