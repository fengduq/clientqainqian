using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTransformDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rtf = GetComponent<RectTransform>();
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 250);
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 250);
    }
}
