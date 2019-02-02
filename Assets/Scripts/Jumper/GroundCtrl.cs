using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCtrl : MonoBehaviour
{
    public GameObject GroundBlock;

    public Transform LastBlock;
    private MoveCtrl MoveInfo;

    public float delay = 0;

    void Awake()
    {
        MoveInfo = GetComponent<MoveCtrl>();

        // TODO: math screen size
        AddGroundBlock(false);
        AddGroundBlock(false);
    }

    private void Start()
    { 
        AddGroundBlock(true);
    }

    void AddGroundBlock(bool useDelay)
    {
        GameObject block = Instantiate(GroundBlock, transform);
        float blockWidth = block.transform.localScale.x;

        if (LastBlock != null) {
            block.transform.position = LastBlock.position + (Vector3.right * blockWidth);
        }
        LastBlock = block.transform;

        delay = blockWidth / MoveInfo.Speed;

        if (useDelay) {
            StartCoroutine(AddGroundBlockDelay(delay));
        }
    }

    IEnumerator AddGroundBlockDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AddGroundBlock(true);
    }
}
