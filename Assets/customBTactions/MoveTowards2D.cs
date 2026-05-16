using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveTowards2D", 
    story: "Moves [Agent] towards [Target]",
    category: "Action/Navigation",
    id: "914845829139a05b13bbcad795b3576e")]
public partial class MoveTowards2D : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<float> Speed = new BlackboardVariable<float>(1f);
    [SerializeReference] public BlackboardVariable<float> StopDistance = new BlackboardVariable<float>(0.2f);
    [SerializeReference] public BlackboardVariable<bool> Rotate = new BlackboardVariable<bool>(false);

    protected override Status OnUpdate()
    {
        if (Agent.Value == null || Target.Value == null)
        {
            return Status.Failure;
        }

        Vector2 current = Agent.Value.transform.position;
        Vector2 target = Target.Value.transform.position;
        float distance = Vector2.Distance(current, target);

        if (Rotate)
        {
            Agent.Value.transform.rotation = utilitiesDB.LookAt2D(target - current);
        }

        if (distance > StopDistance.Value)
        {
            Agent.Value.transform.position = Vector2.MoveTowards(current, target, Speed.Value * Time.deltaTime);
        }
        else
        {
            return Status.Success;
        }

        return Status.Running;
    }
}

