using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinishBehaviour : MonoBehaviour
{
   
    void Update()
    {
        //transform.position += new Vector3(0, 0, 3* Time.deltaTime);
        //позиция х постепенно меняется от текущего значения до 0
        float x = Mathf.MoveTowards(transform.position.x, 0, Time.deltaTime * 2f);
        float z = transform.position.z + 3f * Time.deltaTime;
        transform.position = new Vector3(x, 0, z);

        //поворот по y постепенно меняется от текущего значения до 0
        float rot = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, Time.deltaTime);
        transform.localEulerAngles = new Vector3(0, rot, 0);
    }
}
