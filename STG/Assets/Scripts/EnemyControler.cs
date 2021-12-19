using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    [SerializeField] float countdown = 3;
    [SerializeField] float cooltime = 15;
    [SerializeField] float speed;
    [SerializeField] float Window_x;
    [SerializeField] float Window_y;
    [SerializeField] int Waves;
    [SerializeField] int minEnemy = 3;
    [SerializeField] int maxEnemy = 10;
    [SerializeField] GameObject Enemy;
    CallEnemy call = new CallEnemy();
    float pretime;

    // Start is called before the first frame update
    void Start()
    {
        pretime = -cooltime;
        call.Who = Enemy;
        call.Speed = speed;
        call.window_x = Window_x;
        call.window_y = Window_y;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.fixedTime >= pretime + cooltime + countdown) 
        {
            Debug.Log("wave!");
            Vector3 s;
            Vector3 t;
            int n;
            int pattern = Random.Range(0,3);
            if (pattern == 0)
            {
                for (int i = 1; i <= Random.Range(minEnemy, maxEnemy+1);i++)
                {
                    n = Random.Range(0, 3);
                    if (n == 0)
                    {
                        s = new Vector3(Window_x * -1,Random.Range(Window_y*500,Window_y*1000)/1000,0);
                    }
                    else if (n == 1)
                    {
                        s = new Vector3(Window_x, Random.Range(Window_y*500, Window_y*1000)/1000, 0);
                    }
                    else 
                    {
                        s = new Vector3(Random.Range(-1*Window_x*1000,Window_x*1000)/1000,Window_y,0);
                    }
                    t = new Vector3(Random.Range(-1*Window_x*1000,Window_x*1000)/1000,Random.Range(0f,Window_y*500)/1000,0);
                    call.Call(s,t,0);
                }
            }
            else if (pattern == 1)
            {
                for (int i = 1; i <= Random.Range(minEnemy, maxEnemy + 1);i++)
                {
                    n = Random.Range(0, 3);
                    if (n == 0)
                    {
                        s = new Vector3(-1 * Window_x, Random.Range(Window_y * 500, Window_y * 1000) / 1000, 0);
                    }
                    else if (n == 1)
                    {
                        s = new Vector3(Window_x, Random.Range(Window_y * 500, Window_y * 1000) / 1000, 0);
                    }
                    else
                    {
                        s = new Vector3(Random.Range(-1 * Window_x * 1000, Window_x * 1000) / 1000, Window_y, 0);
                    }
                    t = new Vector3(Random.Range(-1 * Window_x * 1000, Window_x * 1000) / 1000, Random.Range(0f, Window_y * 500) / 1000, 0);
                    call.Call(s,t,1);
                }
            }
            else
            {
                for (int i = 1; i <= Random.Range(minEnemy, maxEnemy + 1);i++)
                {
                    n = Random.Range(0, 3);
                    if (n == 0)
                    {
                        s = new Vector3(-1 * Window_x, Random.Range(Window_y * 500, Window_y * 1000) / 1000, 0);
                    }
                    else if (n == 1)
                    {
                        s = new Vector3(Window_x, Random.Range(Window_y * 500, Window_y * 1000) / 1000, 0);
                    }
                    else
                    {
                        s = new Vector3(Random.Range(-1 * Window_x * 1000, Window_x * 1000) / 1000, Window_y, 0);
                    }
                    t = new Vector3(Random.Range(-1 * Window_x * 1000, Window_x * 1000) / 1000, Random.Range(0f, Window_y * 500) / 1000, 0);
                    call.Call(s,t,Random.Range(0,2));
                }
            }
            pretime = Time.fixedTime;
        }
    }
}
class CallEnemy {
    public GameObject Who;
    public float Speed;
    public float window_x;
    public float window_y;
    public void Call(Vector3 Spown, Vector3 Through, int Pattern) {
        GameObject enemy = GameObject.Instantiate(this.Who,Spown,Quaternion.identity);
        enemy.GetComponent<Enemy_Move>().pattern = Pattern;
        enemy.GetComponent<Enemy_Move>().born = Spown;
        enemy.GetComponent<Enemy_Move>().through = Through;
        enemy.GetComponent<Enemy_Move>().speed = this.Speed;
        enemy.GetComponent<Enemy_Move>().window_X = this.window_x;
        enemy.GetComponent<Enemy_Move>().window_Y = this.window_y;
    }

}
