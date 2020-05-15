using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMover : MonoBehaviour
{

    protected NavMeshAgent agent;

    

    public virtual void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    public virtual void MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public virtual void MoveTo(GameObject target)
    {
        MoveTo(target.transform.position);
    }

    public virtual void Stop()
    {
        agent.isStopped = true;
        
    }

    public virtual void Resume()
    {
        
        agent.isStopped = false;
    }

    public Color DebugLineColor = Color.cyan;

    public virtual void OnDrawGizmos()
    {
        if (agent != null)
        {
            if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
            {
                for (int i = 0; i < agent.path.corners.Length; i++)
                {
                    if (i + 1 < agent.path.corners.Length)
                    {
                        Gizmos.color = DebugLineColor;
                        Gizmos.DrawLine(agent.path.corners[i], agent.path.corners[i + 1]);
                    }
                }
            }
        }
    }
}
