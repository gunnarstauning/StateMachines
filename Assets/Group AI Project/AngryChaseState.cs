using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryChaseState : State {

    public AngryChaseState(StateController stateController) : base(stateController) { }

    public override void CheckTransitions()
    {
        if (!stateController.CheckIfInAngryRange("Player"))
        {
            stateController.SetState(new ChaseState(stateController));
        }
    }
    public override void Act()
    {
        if(stateController.enemyToAngryChase != null)
        {
            stateController.destination = stateController.enemyToAngryChase.transform;
            stateController.ai.SetTarget(stateController.destination);
        }
    }
    public override void OnStateEnter()
    {
        stateController.ChangeColor(Color.red);
        stateController.ai.agent.speed = 2f;
    }
}
