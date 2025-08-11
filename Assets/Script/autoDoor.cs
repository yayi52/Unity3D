using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDoor : MonoBehaviour
{
    public GameObject doorL, doorR;
    public float openSpeed,openAngle;
    private float clockTime;
    // Start is called before the first frame update
    void Start()
    {
        clockTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        clockTime += Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        openAngle = clockTime * openSpeed;
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.z > other.gameObject.transform.position.z)
            {
                doorL.transform.rotation = Quaternion.Euler(0, -60, 0);
                doorR.transform.rotation = Quaternion.Euler(0, 60, 0);
            }
            else if (transform.position.z < other.gameObject.transform.position.z)
            {
                doorL.transform.rotation = Quaternion.Euler(0, 60, 0);
                doorR.transform.rotation = Quaternion.Euler(0, -60, 0);
            }
            /*doorL.transform.position += new Vector3(-1.5f, 0, 0);
            doorR.transform.position += new Vector3(1.5f, 0, 0);*/
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorL.transform.rotation = Quaternion.Euler(0, 0, 0);
            doorR.transform.rotation = Quaternion.Euler(0, 0, 0);
            /*doorL.transform.position += new Vector3(1.5f, 0, 0);
            doorR.transform.position += new Vector3(-1.5f, 0, 0);*/
        }
    }
}
