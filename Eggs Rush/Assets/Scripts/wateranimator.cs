using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wateranimator : MonoBehaviour
 {
	public float speedX = 0.5f;
    public float speedY = 0.5f;
    private float curX;
    private float curY;
 
    // Update is called once per frame
    void Update () {
        curX = Time.time * speedX;
        curY = Time.time * speedY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(curX, curY);
    }

}