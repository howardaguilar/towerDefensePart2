using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Publisher : MonoBehaviour
{
    public UnityEvent DoSomething;

    [ContextMenu("Publish")]
    void Publish()
    {
        Debug.Log("I'm publishing");
        DoSomething.Invoke();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
