using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    TheKiwiCoder.BehaviourTreeInstance behaviourTreeInstance;
    public GameObject waypointParent;
    public int health = 30;

    void Start()
    {
        behaviourTreeInstance = GetComponent<TheKiwiCoder.BehaviourTreeInstance>();
        behaviourTreeInstance.SetBlackboardValue("selfGameObject", GameObject.FindGameObjectWithTag("Enemy"));
        Debug.Log(GameObject.FindGameObjectWithTag("Enemy"));
        behaviourTreeInstance.SetBlackboardValue("waypointParent", waypointParent);
        behaviourTreeInstance.SetBlackboardValue("myTransform", gameObject);
        behaviourTreeInstance.SetBlackboardValue("playerGameObject", GameObject.FindGameObjectWithTag("Player"));
    }
}
