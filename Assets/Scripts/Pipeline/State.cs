using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{
    public Text GiftsLabel;
    public Text MissingLabel;

    private int _grabbedGifts;
    private int _missedGifts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GiftsLabel.text = _grabbedGifts.ToString();
        MissingLabel.text = _missedGifts.ToString();
    }

    public void HandleGrabbedGift()
    {
        _grabbedGifts++;
    }

    public void HandleMissedGift()
    {
        _missedGifts++;
    }
}
