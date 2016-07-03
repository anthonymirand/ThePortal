using UnityEngine;
using System.Collections;

public class Dragon : MonoBehaviour {

    public Animator anim;
    public bool done = false; // you die
    public bool lost = false; // you win
    public bool once = true;

    IEnumerator pause(float time, char select)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("DONE WAITING");
        if (select == 'e')
            done = true;
        if (select == 'd')
        {
            once = false;
            lost = true;
            Debug.Log("YOU DIE");
        }
    }

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        StartCoroutine(pause(26.5f, 'e'));
	}
	
	// Update is called once per frame
	void Update () {
        if (done)
        {
            anim.enabled = true;
        }

        if (once)
        {
            StartCoroutine(pause(40.5f, 'd'));
        }

        if (lost)
        {
            anim.SetBool("biteBool", true);
        } 
	
	}
}
