using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ozoneController : MonoBehaviour
{
    public KeyCode keyToInteract;

    public SewPoint point1;
    public SewPoint point2;

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
                //Get first point
                if(point1 == null)
                {
                    point1 = hit.transform.gameObject.GetComponent<SewPoint>();

                }
       
                //Get second point
                else if(point2 == null)
                {
                    point2 = hit.transform.gameObject.GetComponent<SewPoint>();

                    if(point1.sewPointNumber == point2.sewPointNumber && point1 != point2 && !point1.connected && !point2.connected)
                    {
                        point1.connected = true;
                        point2.connected = true;
                        Debug.DrawLine(point1.transform.position, point2.transform.position, Color.red, 10.0f);
                    }

                    //Reset Points
                    point1 = null;
                    point2 = null;

                }
                
            }
        }

    }
}
