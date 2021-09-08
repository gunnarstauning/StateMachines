using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DiscipleState
{

    protected DiscipleStateController stateController;
    //constructor
    public DiscipleState(DiscipleStateController stateController)
    {
        this.stateController = stateController;
    }
    public abstract void CheckTransitions();

    public abstract void Act();

    public virtual void OnStateEnter() { }

    public virtual void OnStateExit() { }



	
}
