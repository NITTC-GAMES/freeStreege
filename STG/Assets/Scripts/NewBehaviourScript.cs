using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float ran; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Random.seed = Random.Range((int)Time.time,(int)(Time.deltaTime * 100000000000));
        ran = Random.Range(-1.1f,-3.2f);
    }
}
