using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var myCollider = GetComponent<BoxCollider>();
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 5000f))
            {
                if (hit.collider.gameObject.tag == "Gift")
                {
                    Destroy(hit.collider.gameObject);

                    var state = GameObject.Find("Root").GetComponent<State>();
                    state.HandleGrabbedGift();
                }
            }
        }
    }
}
