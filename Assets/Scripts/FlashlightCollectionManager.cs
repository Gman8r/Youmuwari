using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightCollectionManager : MonoBehaviour
{
    [SerializeField]
    private int baseOrderInLayer = 50;
    [SerializeField]
    private int baseDelay = 1;
    [SerializeField]
    private int delayPerLight = 5;
    [SerializeField]
    private float scaleLowerPerLight = .05f;
    
	void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var panel = transform.GetChild(i);
            panel.GetComponent<SpriteRenderer>().sortingOrder = baseOrderInLayer + i;

            var light = panel.GetChild(0);
            var lightMask = light.GetComponent<SpriteMask>();
            lightMask.frontSortingOrder = baseOrderInLayer + i;
            lightMask.backSortingOrder = baseOrderInLayer + i - 1;

            light.GetComponent<Flashlight>().tickDelay = baseDelay + (delayPerLight * i);
            var animation = light.GetComponent<FlashlightAnimation>();

            animation.scaleRange -= Vector2.one * (scaleLowerPerLight * i);
        }
	}
	
	void Update ()
    {
		
	}
}