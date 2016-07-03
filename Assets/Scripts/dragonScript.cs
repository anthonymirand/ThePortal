using UnityEngine;
using System.Collections;

public class dragonScript : MonoBehaviour
{

   
    public bool isDead = false;
    public int fadeSpeed = 0;
    private bool isDone = false;
    private bool isKilled = false;
    private Color[] matCol;
    private Color newColor;
    private float alfa = 0;
    private float red = 0;
    private float green = 0;
    private float blue = 0;
    Renderer[] renderers;


    // Use this for initialization
    void Start()
    {

        renderers = GetComponentsInChildren<Renderer>();
        isDead = true;

    }


    // Update is called once per frame
    void Update()
    {

        if (isDead)
        {

            if (!isDone)
            {

                foreach (Renderer r in renderers)
                {

                    alfa = r.material.color.a - (5 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    red = r.material.color.r + (5 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    green = r.material.color.g + (5 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    blue = r.material.color.b + (5 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    newColor = new Color(red, green, blue, alfa);
                    r.material.SetColor("_Color", newColor);
                    isDone = red >= 30 ? true : false;

                }

            }
            else
            {

                foreach (Renderer r in renderers)
                {

                    alfa = r.material.color.a - (7 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    red = r.material.color.r - (7 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    green = r.material.color.g - (7 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    blue = r.material.color.b - (7 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    newColor = new Color(red, green, blue, alfa);
                    r.material.SetColor("_Color", newColor);
                    isKilled = red <= 0 ? true : false;

                }

            }

            if (isKilled)
            {
                foreach (Renderer r in renderers)
                    r.enabled = false;
            }

        }
    }
}
