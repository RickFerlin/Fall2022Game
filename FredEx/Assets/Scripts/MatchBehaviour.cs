using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehaviour : MonoBehaviour
{
    public ID idObj;
    private bool hasPackage;
    private float destroyDelay = 0.5f;
    [SerializeField] private GameObject car; 
    
    public UnityEvent pickUpEvent, matchEvent, noMatchEvent, noMatchDelayedEvent;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        var tempObj = other.GetComponent<IDContainerBehaviour>();
        if (tempObj == null)
            yield break;
            
        var otherID = tempObj.idObj;
        if (otherID == idObj)
        {
            matchEvent.Invoke();
        }
        else
        {
            noMatchEvent.Invoke();
            yield return new WaitForSeconds(0.5f);
            noMatchDelayedEvent.Invoke();
        }
        

        if (other.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            idObj = otherID;
        }
    }
}
