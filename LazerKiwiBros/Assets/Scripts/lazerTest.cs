using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerTest : MonoBehaviour
{

    public Transform[] transforms;
    LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transforms[0].position);
        lr.SetPosition(1, transforms[1].position);

       
        
    }
}
