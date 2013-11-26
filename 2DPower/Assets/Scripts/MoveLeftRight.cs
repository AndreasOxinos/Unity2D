using System.Security.Cryptography;
using UnityEngine;
using System.Collections;

public class MoveLeftRight : MonoBehaviour
{
    public float speed = 1.0f;
    public string axisName = "Horizontal";

    private Animator anim;
    
    void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
    }
	
	void Update ()
	{
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis(axisName)));
	    if (Input.GetAxis(axisName) < 0)
	    {
	        Vector3 newScale = transform.localScale;
	        newScale.x = -1.0f;
	        transform.localScale = newScale;
	    }
	    else if (Input.GetAxis(axisName) > 0)
	    {
            Vector3 newScale = transform.localScale;
            newScale.x = 1.0f;
            transform.localScale = newScale;
	    }
	    transform.position += transform.right * Input.GetAxis(axisName) * speed * Time.deltaTime;
	}
}
 