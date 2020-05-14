using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public GameObject cra;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(obj, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
       float KeyVertical = Input.GetAxis("Vertical");
        float KeyHorizontal = Input.GetAxis("Horizontal");
        Debug.Log("Vertical"+ KeyVertical);
        Debug.Log("KeyVertical"+KeyVertical);
        Vector3 vector=this.transform.position;
        Vector3 newVector = new Vector3(vector.x + KeyHorizontal, vector.y, vector.z + KeyVertical);
        this.transform.position = newVector;
   
        /**
         * 屏幕坐标系
         */
         /**
          * 
         Debug.Log("Screen.width" + Screen.width);
         Debug.Log("Screen.height" + Screen.height);
         Vector3 screenPos = cra.GetComponent<Camera>().WorldToScreenPoint(this.gameObject.transform.position);
         Debug.Log("Screen.now width" + screenPos.x);
         Debug.Log("Screen.now height" + screenPos.y);
         float KeyVertical = Input.GetAxis("Vertical");
         float KeyHorizontal = Input.GetAxis("Horizontal");
         screenPos.x = screenPos.x + KeyHorizontal;
         screenPos.y = screenPos.y + KeyVertical;
         Vector3  worldPos= cra.GetComponent<Camera>().ScreenToWorldPoint(screenPos);
        
         this.gameObject.transform.position = new Vector3(worldPos.x, worldPos.y, worldPos.z);
        **/
    }
}
