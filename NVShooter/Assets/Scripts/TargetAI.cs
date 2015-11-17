using UnityEngine;
using System.Collections;

public class TargetAI : MonoBehaviour {

	//public Collider TargetActiveRange;
	public float moveSpeed;
	public float rotateSpeed;

    public Transform PlayerOfInterest;

    public enum TargetActions
    {
        IDLE,
        WANDER,
        AVOID,
        SEEK
    }

    public TargetActions targetAction;
    public bool inRange;

	// Use this for initialization
	void Start () {
        inRange = false;
        PlayerOfInterest = null;
    }
	
	// Update is called once per frame
	void Update () {
	    if(inRange)
        {
            switch(targetAction)
            {
                case TargetActions.IDLE:
                    Idle();
                    break;
                case TargetActions.WANDER:
                    Wander();
                    break;
                case TargetActions.AVOID:
                    Avoid();
                    break;
                case TargetActions.SEEK:
                    Seek();
                    break;
                default:
                    break;
            }
        }
	}

	void Idle ()
	{

	}

	void Wander()
	{
        float newFloat = Random.Range(0, 1);
        float turnPercent = 0.2f;
        if(newFloat < turnPercent)
        {
            transform.Rotate(0, -turnPercent, 0, Space.World);
        }
        else if(newFloat < (1 - turnPercent))
        {
            transform.Rotate(0, -turnPercent, 0, Space.World);
        }

        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

	void Avoid()
	{
        Vector3 direction = (transform.position - PlayerOfInterest.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    void Seek ()
	{
        Vector3 direction = (PlayerOfInterest.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }
}
