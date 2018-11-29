using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GOPE_Goal_Something : Goal {

    public GOPE_Goal_Something() { }

    public override void OnGoalInitialize(IGoap igoap)
    {
        this.igoap = igoap;
    }

    public override void OnGoalSetup() { }
    public override void OnGoalFinished() { }
    public override void OnGoalAborted() { }
    public override bool IsGoalRelevant() { return true; }
}
