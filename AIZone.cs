using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class AIZone : MonoBehaviour
{
    private List<GameObject> _targetList = new List<GameObject>();
	public GameObject closesObj;
	[HideInInspector] public string targetTag;

    private void Update()
    {
        closesObj = ClosestObject();
		if (closesObj != null )
		{
			Debug.Log(closesObj.name);
		}	
    }
    
    public GameObject ClosestObject()
    {
	    if (!_targetList.Any())
	    {
		    Debug.LogWarning("No targets in the list");
		    return null;
	    }

	    return _targetList.OrderBy(obj => Vector3.Distance(transform.position, obj.transform.position)).First();
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag(targetTag))
		{
			AddTarget(other.gameObject);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag(targetTag))
		{			
			DeleteTarget(other.gameObject);
		}
	}

	public void AddTarget(GameObject target)
    {
	    _targetList.Add(target);
        Debug.Log(target.name + " Added to the list");
		
	}
	
    public void DeleteTarget(GameObject target)
    {
	    _targetList.Remove(target);
		Debug.Log(target.name + " Removed from the list");		
	}
}