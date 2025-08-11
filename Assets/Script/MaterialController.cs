using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public Color color;
    public float clock = 0;
    public GameObject cube,cube2;
    public Material shaderGraph;
    private Material testColor,testColor2;
    private float randomR, randomG, randomB;
    private float fresnelPower, FPM;
    // Start is called before the first frame update
    void Start()
    {
        fresnelPower = 0.7f;
        FPM = 1f;
        testColor = cube.GetComponent<MeshRenderer>().material;
        testColor2 = cube2.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        fresnelPower += Time.deltaTime * FPM;
        /*if (fresnelPower > 5f)
        {
            FPM *= -1;
        }
        if (fresnelPower < 0f)
        {
            FPM *= -1;
        }*/
        if (clock > 0.5f)
        {
            randomR = Random.Range(0, 1f);
            randomG = Random.Range(0, 1f);
            randomB = Random.Range(0, 1f);
            color = new Vector4(randomR, randomG, randomB, 255);
            clock = 0;
            Adapt();
        }
        testColor.SetTextureOffset("_MainTex", new Vector2(0,fresnelPower));
        //testColor.SetTextureScale("_MainTex", new Vector2(fresnelPower, 0));
    }
    private void Adapt()
    {
        testColor2.SetColor("_Color", color);
        testColor.SetFloat("_Metallic", randomB);
        
        shaderGraph.SetFloat("_fresnelPower",fresnelPower);
    }
}
