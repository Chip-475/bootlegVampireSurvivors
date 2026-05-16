using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Parent", story: "Sets parent of [targetObject] to [targetParent]", category: "Action/Transform", id: "f32efd48268c9600b416f5b29f5e1a90")]
public partial class SetParent : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> TargetObject;
    [SerializeReference] public BlackboardVariable<GameObject> TargetParent;
    [SerializeReference] public BlackboardVariable<bool> WorldPositionStays = new BlackboardVariable<bool>(false);

    protected override Status OnStart()
    {
        if (TargetObject == null || TargetParent == null) return Status.Failure;

        TargetObject.Value.transform.SetParent(TargetParent.Value.transform, WorldPositionStays.Value);
        return Status.Success;
    }
}