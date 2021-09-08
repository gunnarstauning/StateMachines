using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscipleAngryState : DiscipleState
{
    public DiscipleAngryState(DiscipleStateController stateController) : base(stateController) { }

    public override void CheckTransitions()
    {
        if (!stateController.CheckIfInRange("Player"))
        {
            stateController.SetState(new DiscipleWanderState(stateController));
        }
        if (stateController.CheckIfInRange("Player") && !stateController.CheckIfInAngerRange("Player"))
        {
            stateController.SetState(new DiscipleChaseState(stateController));
        }
    }
    public override void Act()
    {
        if (stateController.enemyToChase != null)
        {
            stateController.destination = stateController.enemyToChase.transform;
            stateController.ai.SetTarget(stateController.destination);
        }
    }
    public override void OnStateEnter()
    {
        stateController.ChangeColor(Color.black);
        stateController.ai.agent.speed = .75f;
    }
}
