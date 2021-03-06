﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ozoneController : MonoBehaviour
{
    public KeyCode keyToInteract;

    public SewPoint point1;
    public SewPoint point2;

    public OzoneLine line;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(keyToInteract))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

            if(hit.collider != null)
            {
                if(hit.transform.gameObject.tag == "SewPoint")
                {
                    //Get first point
                    if (point1 == null)
                    {
                        point1 = hit.transform.gameObject.GetComponent<SewPoint>();

                    }

                    //Get second point
                    else if (point2 == null)
                    {
                        point2 = hit.transform.gameObject.GetComponent<SewPoint>();

                        if (point1.sewPointSideNumber != point2.sewPointSideNumber && point1 != point2)
                        {
                            point1.connected = true;
                            point2.connected = true;

                            OzoneLine newLine = Instantiate(line);

                            newLine.GetComponent<LineRenderer>().SetPosition(0, point1.transform.position);
                            newLine.GetComponent<LineRenderer>().SetPosition(1, point2.transform.position);
                        }

                        //Reset Points
                        point1 = null;
                        point2 = null;

                    }
                }

                
            }
        }

    }
}
