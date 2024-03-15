using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour  
{
    MapControler mc;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        mc = FindObjectOfType<MapControler>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
            mc.currentChunk = target;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
            if(mc.currentChunk == target)
            {
                mc.currentChunk = null ;
            }
        }
    }
}
