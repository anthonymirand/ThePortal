using UnityEngine;
using System.Collections;

public class dragonExplosion : MonoBehaviour
{

    public bool isDead = false;
    private bool isKilled = false;
    private bool isDone = false;
    private Color[] matCol;
    private Color newColor;
    private float alfa = 0;
    private float red = 0;
    private float green = 0;
    private float blue = 0;
    private float grow = 0;
    private float scale = 0;
    private Renderer[] renderers;

    // Use this for initialization
    void Start()
    {

        renderers = gameObject.GetComponentsInChildren<Renderer>();
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
                    scale += (0.03f * Mathf.Lerp(0f, 1f, Time.deltaTime / 20));
                    newColor = new Color(red, green, blue, alfa);
                    r.material.SetColor("_Color", newColor);
                    isDone = transform.localScale.x >= 10f ? true : false;
                    transform.localScale += new Vector3(scale, scale, scale);


                }


            }
            else
            {

                foreach (Renderer r in renderers)
                {
                    alfa = r.material.color.a - (5 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    red = r.material.color.r - (5 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    green = r.material.color.g - (5 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    blue = r.material.color.b - (5 * Mathf.Lerp(0f, 1f, Time.deltaTime / 1));
                    scale -= (0.3f * Mathf.Lerp(0f, 1f, Time.deltaTime / 20));
                    newColor = new Color(red, green, blue, alfa);
                    r.material.SetColor("_Color", newColor);
                    isKilled = transform.localScale.x <= 0 ? true : false;
                    transform.localScale += new Vector3(scale, scale, scale);

                }


            }

            if (isKilled)
            {

                foreach (Renderer r in renderers)
                {
                    r.enabled = false;
                }

            }
        }
    }
}
