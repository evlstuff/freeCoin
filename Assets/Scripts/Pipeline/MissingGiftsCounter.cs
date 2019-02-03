using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingGiftsCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Gift")
        {
            var state = GameObject.Find("Root").GetComponent<State>();
            state.HandleMissedGift();

            Destroy(collision.collider.gameObject);
        }
    }
}
