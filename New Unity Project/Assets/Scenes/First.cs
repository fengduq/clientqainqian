using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gameObjects =GameObject.FindGameObjectsWithTag("person");
        int min = int.MaxValue;
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i].GetComponent<NewBehaviourScript>() != null) 
            {
                if (gameObjects[i].GetComponent<NewBehaviourScript>().x < min)
                {
                    min = gameObjects[i].GetComponent<NewBehaviourScript>().x;
                }
            }
        }
        Debug.Log("min:" + min);
        NewBehaviourScript[] newBehaviourScript = GameObject.FindObjectsOfType<NewBehaviourScript>();
        for (int i = 0; i < newBehaviourScript.Length; i++)
        {
            if (newBehaviourScript[i].gameObject.GetComponent<NewBehaviourScript>() != null)
            {
                if (newBehaviourScript[i].gameObject.GetComponent<NewBehaviourScript>().x < min)
                {
                    min = newBehaviourScript[i].gameObject.GetComponent<NewBehaviourScript>().x;
                }
            }
        }

        Debug.Log("next min:"+min);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
