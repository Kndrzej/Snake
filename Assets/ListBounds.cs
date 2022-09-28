using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider gridArea = this.GetComponent<BoxCollider>();
        Debug.Log(gridArea.bounds.min.x + "  " + gridArea.bounds.max.x + " " + gridArea.bounds.min.y + "  " + gridArea.bounds.max.y);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
