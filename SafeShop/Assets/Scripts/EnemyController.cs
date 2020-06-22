using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 3f;

    private Transform target;
    private NavMeshAgent agent;
    private ThirdPersonCharacter character;
    private Vector3 startPosition;
    private Vector3 roamPosition;

    private enum State
    {
        Roaming,
        ChaseTarget,
        Stop,
        GoToStartPosition
    }
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        startPosition = transform.position;
        roamPosition = GetRoamingPostion();
        //Debug.Log("INITIAL POS=" + roamPosition);
        GetComponent<SphereCollider>().radius = lookRadius;
        state = State.Roaming;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            default:
            case State.Roaming:
                //Check if roam position is reachable
                NavMeshPath path = new NavMeshPath();
                agent.CalculatePath(roamPosition, path);
                //Debug.Log("Path status" + path.status);
                if (path.status != NavMeshPathStatus.PathComplete)
                {
                    roamPosition = GetRoamingPostion();
                    //Debug.Log("Path cannot reach. new dest=" + roamPosition);
                }
                agent.isStopped = false;
                agent.SetDestination(roamPosition);
                character.Move(agent.desiredVelocity, false, false);
                float reachedPositionDist = 1f;
                //Debug.Log("DIST=" + Vector3.Distance(transform.position, roamPosition));
                if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDist)
                {
                    roamPosition = GetRoamingPostion();
                    // Debug.Log("New roam POS=" + roamPosition);
                }
                //Use FindTarget to increase difficulty
                //FindTarget();
                //Debug.Log("ROAMING");
                StopRoaming();
                break;
            case State.ChaseTarget:
                //Debug.Log("CHASING");
                agent.SetDestination(target.position);
                character.Move(agent.desiredVelocity, false, false);

                if (Vector3.Distance(target.position, transform.position) <= agent.stoppingDistance)
                {
                    FaceTarget();
                }

                float StopChaseDist = 3f;
                if (Vector3.Distance(target.position, transform.position) > StopChaseDist)
                {
                    state = State.GoToStartPosition;
                }
                break;
            case State.GoToStartPosition:
                //Debug.Log("GO TO START");
                agent.SetDestination(roamPosition);
                float reachedStartPos = 1f;
                //Debug.Log("DIST=" + Vector3.Distance(transform.position, roamPosition));
                if (Vector3.Distance(transform.position, startPosition) < reachedStartPos)
                {
                    state = State.Roaming;
                }
                break;
            case State.Stop:
                //Debug.Log("STOP ROAMING");
                state = State.Roaming;
                break;
        }

       

    }
    IEnumerator Waiter()
    {
        Debug.Log("YIELD DONE");
        yield return new WaitForSeconds(1f);
        //my code here after 3 seconds
        Debug.Log("YIELD DONE");
        state = State.Roaming;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void FindTarget()
    {

        if (Vector3.Distance(target.position, transform.position) <= lookRadius)
        {
            state = State.ChaseTarget;
        }
    }

    private void StopRoaming()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.isStopped =true;
            //character.Move(agent.desiredVelocity, false, false);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
            state = State.Stop;
        }
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 4f);
    }
    private Vector3 GetRoamingPostion()
    {
        return startPosition + GetRandomDirection() * Random.Range(5f, 6f);
    }

    //Utilities
    public static Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        //return new Vector3(1 ,1, Random.Range(-1f, 1f)).normalized;
    }
}
