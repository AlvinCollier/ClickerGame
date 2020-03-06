using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAnimation : MonoBehaviour
{

    float currentScale = 1;
    public float scalingRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScale *= scalingRate;
        transform.localScale = new Vector3(currentScale, currentScale, transform.localScale.z);
        GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, currentScale);
        if(transform.localScale.x < .1)
        {
            Destroy(this.gameObject);
        }
    }
}
