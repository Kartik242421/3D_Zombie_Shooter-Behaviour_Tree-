using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.AI;

[System.Serializable]
public class GoToTarget : ActionNode
{
    private Animator anim;
    private NavMeshAgent agent;

    public NodeProperty<GameObject> selfGameObject, targetObject;
    private Transform myTransform, nextWavepointTransform;
    private Vector3 direction;
    private float speed = 0.5f;
    protected override void OnStart()
    {
        myTransform = selfGameObject.Value.transform;
        nextWavepointTransform = targetObject.Value.transform;
        agent = selfGameObject.Value.GetComponent<NavMeshAgent>();
        anim = selfGameObject.Value.GetComponent<Animator>();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (nextWavepointTransform != null)
        {
            moveToTarget();
        }

        return State.Success;
    }

    void moveToTarget()
    {
        //direction = nextWavepointTransform.position - myTransform.position;
        //myTransform.Translate(direction * speed * Time.deltaTime);
        agent.SetDestination(nextWavepointTransform.position);
        anim.SetBool("move", true);
        agent.speed = 0.5f;
    }
}