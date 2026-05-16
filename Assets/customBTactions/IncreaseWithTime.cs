using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Variable += Time.DeltaTime", story: "Increases [Float] by Time.deltaTime", category: "Action/Blackboard", id: "aab436de5b06f48e82d34b11fd3cd45d")]
public partial class IncreaseWithTime : Action
{
    [SerializeReference] public BlackboardVariable<float> Float;

    protected override Status OnUpdate()
    {
        Float.Value += Time.deltaTime;
        return Status.Running;
    }
}

