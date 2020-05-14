using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lay : MonoBehaviour
{
    // Start is called before the first frame update
    private Ray ray;
    private RaycastHit raycastHit;
    int lay;
    private Dictionary<Transform,  float> dic = new Dictionary<Transform,  float>();
    void Start()
    {
        ray = new Ray(transform.position, transform.forward);
        string[] strs = new string[] { "Cube" };
        lay = LayerMask.GetMask(strs);
    }

    // Update is called once per frame
    void Update()
    {
        //
        foreach (KeyValuePair<Transform, float> kvp in dic)
        {
            kvp.Key.Rotate(Vector3.up * Time.deltaTime, kvp.Value);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 vec = Input.mousePosition;
            Vector3 world = Camera.main.ScreenToWorldPoint(vec);
            ray  = GetComponent<Camera>().ScreenPointToRay(vec);
            Vector3 worldName = world - transform.position ;
            //transform.position = new Vector3(worldName.x, worldName.y, worldName.z);
            //transform.forward = ray.direction;
            //ray = new Ray(transform.position, transform.forward);
            RaycastHit raycastHit = new RaycastHit();
            Physics.Raycast(ray, out raycastHit, 100f);
            this.raycastHit = raycastHit;
            
            if ( lay == (1 << raycastHit.transform.gameObject.layer) )
            {
                List<Transform> list = new List<Transform>();
                foreach (Transform transform in dic.Keys)
                {
                    list.Add(transform);
                }
                foreach (Transform transform in list)
                {
                    dic[transform] = 0;
                }


                if (!dic.ContainsKey(raycastHit.transform))
                {
                    dic.Add(raycastHit.transform, 0);
                }
                dic[raycastHit.transform] = 10;
            }
        }
        Debug.DrawLine(transform.position, raycastHit.point, Color.red);
    }
}
