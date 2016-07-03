using UnityEngine;
using System.Collections;

public class DragonManager : MonoBehaviour
{
    public Transform target;
    public float speed = 2;

    private float explosion = 4;
    private bool collided = false;
    private Vector3 location;
    private bool doneWaiting_enter = false;

    IEnumerator waitCustom(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("DONE WAITING FOR CLONE");
        doneWaiting_enter = true;
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(waitCustom(26.5f));   
        location = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (doneWaiting_enter)
            if (!collided || transform.position != location)
            {
               float step = speed * Time.deltaTime;
               transform.position = Vector3.MoveTowards(transform.position, location, step);
            }
    }

    void OnCollisionStay(Collision collision)
    {
        collided = true;
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * explosion, ForceMode.Impulse);
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Physics.IgnoreCollision(collision.transform.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
