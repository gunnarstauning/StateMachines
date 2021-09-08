using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscipleReproduceState : DiscipleState
{

    public DiscipleReproduceState(DiscipleStateController stateController) : base(stateController) { }


    float timeLimit;
    float timer;
    Vector3 clone;

    public override void CheckTransitions()
    {
        if (timer > timeLimit)
        {
            clone = stateController.GetRandomPoint();
            stateController.Reproduce(clone);
            stateController.SetState(new DiscipleMakeNavPoints(stateController));
        }

    }
    public override void Act()
    {
        timer += Time.deltaTime;
        if (stateController.destination == null || stateController.ai.DestinationReached())
        {
            stateController.destination = stateController.GetWanderPoint();
            stateController.ai.SetTarget(stateController.destination);
        }
    }
    public override void OnStateEnter()
    {
        timer = 0f;
        timeLimit = 2f;
        stateController.destination = stateController.GetWanderPoint();
        if (stateController.ai.agent != null)
        {
            stateController.ai.agent.speed = .2f;
        }
        stateController.ai.SetTarget(stateController.destination);
        stateController.ChangeColor(Color.yellow);
    }
}
