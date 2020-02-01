using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class factoryPlayerController : MonoBehaviour
{
    public KeyCode keyToInteract;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToInteract))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

            if (hit.collider != null)
            {
                smokeStack selectedSmokeStack = hit.transform.gameObject.GetComponent<smokeStack>();

                selectedSmokeStack.CorkIt();

            }
        }
    }
}
