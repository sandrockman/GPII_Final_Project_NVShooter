using UnityEngine;
using System.Collections;

public class TargetDetection : MonoBehaviour {

    public TargetAI targetAI;

    // Use this for initialization
    void Start()
    {
        targetAI = GetComponentInParent<TargetAI>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            targetAI.inRange = true;
            if(targetAI.PlayerOfInterest == null)
            {
                targetAI.PlayerOfInterest = other.transform;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            targetAI.inRange = true;
            if (targetAI.PlayerOfInterest == null)
            {
                targetAI.PlayerOfInterest = other.transform;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetAI.inRange = false;
            targetAI.PlayerOfInterest = null;
        }
    }
}
