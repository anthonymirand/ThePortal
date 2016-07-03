using UnityEngine;
using System.Collections;

public class eggManager : MonoBehaviour {

    public GameObject portal;
    private bool move = false;
    private bool once = true;
    private float speed = 2;
    public bool win = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (move)
        {
            float step = speed * Time.deltaTime;
            Vector3 target = portal.transform.position;
            if (once)
            {
                Debug.Log("MOVED EGG");
                target.y = -1;
                once = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
	}

    void OnSelect()
    {
        move = true;
    }

    void OnTriggerEnter(Collider col)
    {
        win = true;
    }
}
