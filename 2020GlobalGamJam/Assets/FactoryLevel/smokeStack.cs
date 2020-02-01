using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeStack : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite corkSprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CorkIt()
    {
        spriteRenderer.sprite = corkSprite;
    }
}
