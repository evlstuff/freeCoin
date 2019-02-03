using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int _grabbedGifts = 0;

    public Text CounterLabel;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CounterLabel.text = _grabbedGifts.ToString();
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
                    _grabbedGifts++;
                }
            }
        }
    }
}
