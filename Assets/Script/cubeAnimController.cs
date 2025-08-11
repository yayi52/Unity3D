using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeAnimController : MonoBehaviour
{
    private Animator cubeAnim;
    private bool setter;
    [SerializeField] private float clockTime;
    // Start is called before the first frame update
    void Start()
    {
        setter = false;
        cubeAnim = GetComponent<Animator>();
        cubeAnim.SetBool("Roatate", setter);
        clockTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        clockTime += Time.deltaTime;
        if (clockTime > 5.0f)
        {
            setter = !setter;
            cubeAnim.SetBool("Rotate", setter);
            clockTime = 0f;
        }
    }
}
