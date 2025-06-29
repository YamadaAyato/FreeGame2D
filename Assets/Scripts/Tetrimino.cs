using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrimino : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;  //(-1,0)À•W‚ğˆÚ“®
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;  //(1,0)À•W‚ğˆÚ“®
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.Rotate(0, 0, 90);  //¶‰ñ“]
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            transform.Rotate(0, 0, -90);  //‰E‰ñ“]
        }

        //transform.position = Vector3.down;

    }
}
