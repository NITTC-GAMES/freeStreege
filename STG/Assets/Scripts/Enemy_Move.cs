using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public int pattern;
    public Vector3 born;
    public Vector3 through;
    public float speed;
    public float window_X;
    public float window_Y;
    float startFrame;
    [SerializeField]  float a;
    [SerializeField]  float b;
    [SerializeField]  Vector3 deg;
    // Start is called before the first frame update
    void Start()
    {
        startFrame = Time.frameCount;
        if (pattern == 0)
        {
            a = (born.y - through.y)*2 / (born.x - through.x)*(born.x - through.x);
            b = (born.x - through.x) / Mathf.Abs(born.x - through.x);
        }
        else
        {
            a = (born.y - through.y) / (born.x - through.x);
            b = (born.x - through.x) / Mathf.Abs(born.x - through.x);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (pattern == 0)
        {
            float c = a * transform.position.x + through.x * -a;
            deg = new Vector3(1, c, 0) * b / Mathf.Sqrt(1 + c * c) * speed;
            transform.position -= deg;
        }
        else 
        {
            deg = new Vector3(1, a, 0) * b / Mathf.Sqrt(1 + a * a) * speed;
            transform.position -= deg;
        }
        
        if ((this.transform.position.x > window_X ||
             this.transform.position.x < -window_X ||
             this.transform.position.y > window_Y ||
             this.transform.position.y < -window_Y)
             && startFrame != Time.frameCount)
        {
            Destroy(this.gameObject);
        }
        
    }
}
