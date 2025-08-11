using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject pointLight;
    public float lightIntensity, clockTime;
    public Light lightC;
    private bool state;
    // Start is called before the first frame update
    void Start()
    {
        clockTime = 0f;
        lightC.intensity = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        clockTime += Time.deltaTime;
        if (clockTime > 0.2f)
        {
            lightIntensity = Random.Range(0, 5f);
            pointLight.GetComponent<Light>().intensity = lightIntensity;
            if (lightC.intensity >= 5f)
            {
                state = false;
            }
            else if (lightC.intensity <= 0f)
            {
                state = true;
            }
            clockTime = 0f;
        }
        lightCIntensity();
    }
    private void lightCIntensity()
    {
        if (state)
        {
            lightC.intensity+= Time.deltaTime;
        }
        else if (!state)
        {
            lightC.intensity-= Time.deltaTime;
        }
    }
}
