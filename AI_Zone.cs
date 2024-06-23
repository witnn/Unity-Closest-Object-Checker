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
		try
		{
			float[] distances = new float[AI_List.Count];
			for (int i = 0; i < AI_List.Count; i++)
			{
				GameObject obj = (GameObject)AI_List[i];
				distances[i] = Vector3.Distance(transform.position, obj.transform.position);
			}
			float[] sortedDistances = InsertionSort(distances);
			float closestDistance = sortedDistances[0];
			for (int i = 0; i < AI_List.Count; i++)
			{
				GameObject obj = (GameObject)AI_List[i];
				float distance = Vector3.Distance(transform.position, obj.transform.position);
				if (distance == closestDistance)
				{
					return (GameObject)AI_List[i];
				}
			}
		}
		catch(IndexOutOfRangeException e)
		{	
			Debug.Log("Hi, you're not close to an item.");
			return null;
		}
		
		return null;
	}

	float[] InsertionSort(float[] array)
	{
		float[] sortedArray = array;
		int n = sortedArray.Length;
		for (int i = 1; i < n; i++)
		{
			float key = sortedArray[i];
			int j = i - 1;

			
			while (j >= 0 && sortedArray[j] > key)
			{
				sortedArray[j + 1] = sortedArray[j];
				j--;
			}
			sortedArray[j + 1] = key; 
		}
		return sortedArray;
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
