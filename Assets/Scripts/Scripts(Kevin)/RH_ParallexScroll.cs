using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RH_ParallexScroll : MonoBehaviour {

    public float speed;

    Vector2 offset;
    float lastX;

    void Start()
    {
        offset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
        lastX = offset.x;
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.deltaTime * speed + lastX, 1);
        Vector2 newOffSet = new Vector2(x, offset.y);
        lastX = newOffSet.x;
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", newOffSet);
    }
}
