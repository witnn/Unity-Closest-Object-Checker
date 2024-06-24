using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Zone : MonoBehaviour
{
	private ArrayList AI_List;
	public GameObject closesObj;
	public string _tag = "AI";

	void Start()
	{
		AI_List = new ArrayList();
	}

    	void Update()
	{
        	closesObj = ClosestObject();
		if (closesObj != null )
		{
  			Debug.Log(closesObj.name);
		}	
	}

	public GameObject ClosestObject()
	{
		float closestDistance = 99999.0f;
		GameObject closestObj = null; 
		for (int i = 0; i < AI_List.Count; i++)
		{
			GameObject obj = (GameObject)AI_List[i];
			float distance = Vector3.Distance(transform.position, obj.transform.position);
			if (distance < closestDistance)
			{
   				closestDistance = distance;
       				closestObj = obj
			}
		}	
		return closestObj;
	}

	private void OnTriggerEnter(Collider other)
	{   
		if(other.gameObject != null)
        	{		
			if (other.gameObject.tag.Equals(_tag))
            		{
				AddAI(other.gameObject);
			}
		}
	}
 
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject != null)
		{		
			if (other.gameObject.tag.Equals(_tag))
			{			
				DeleteAI(other.gameObject);
			}
		}
	}

	public void AddAI(GameObject AI)
    	{
		AI_List.Add(AI);
  		Debug.Log(AI.name + " Added to the list");		
	}
 
    	public void DeleteAI(GameObject AI)
    	{
		AI_List.Remove(AI);
		Debug.Log(AI.name + " Removed from the list");		
	}
}
