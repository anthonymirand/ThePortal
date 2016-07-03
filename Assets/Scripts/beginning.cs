using UnityEngine;
using System.Collections;

public class beginning : MonoBehaviour {

    public GameObject plane;
    private bool delete = false;

	// Use this for initialization
	void Start () {
        plane.SetActive(true);
        StartCoroutine(pause(3));
	}

    IEnumerator pause(float time)
    {
        yield return new WaitForSeconds(time);
        delete = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (delete)
        {
            plane.SetActive(false);
            delete = false;
        }

	}
}
