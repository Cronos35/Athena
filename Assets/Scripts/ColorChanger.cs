using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(bool changeToDefaultColor, bool correct)
    {
        if (changeToDefaultColor)
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = correct ? Color.green : Color.red;
        }
    }
}
