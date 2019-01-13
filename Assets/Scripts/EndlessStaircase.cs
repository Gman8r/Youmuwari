using System;
using System.Collections.Generic;
using UnityEngine;

public class EndlessStaircase : MonoBehaviour
{

    [SerializeField]
    public GameObject StairPrefab;
    [SerializeField]
    public GameObject EndStairPrefab;

    [SerializeField]
    public float Speed = 4f;
    //Has to be odd
    [SerializeField]
    public int PoolSize = 5;

    private IList<IStairItem> stairPool;
    private bool shouldEndAsap = false;
    private bool stopped = false;
    private float offsetYTop = 0f;
    private float offsetYBottom = 0f;

    void Start()
    {
        stairPool = new List<IStairItem>(PoolSize);

        //Distribute the stairs evenly around the center
        for (int i = 0; i < PoolSize; i++)
        {
            var go = Instantiate(
                StairPrefab,
                transform);
            var stairItem = go.GetComponent<IStairItem>();
            var multiplier = i - Math.Round(PoolSize / 2f);
            go.transform.localPosition += new Vector3(0, (float)multiplier * stairItem.Height, 0);
            stairPool.Add(stairItem);
            Debug.Log(multiplier * stairItem.Height);
        }

        //Calculate spawn/disposal points
        float aggregatedStaircaseHeigth = PoolSize * stairPool[0].Height;
        offsetYBottom = -aggregatedStaircaseHeigth / 2;
        offsetYTop = offsetYBottom + aggregatedStaircaseHeigth;
    }

    void Update()
    {
        if (!stopped)
        {
            //Should use callbacks instead of iterating
            foreach (IStairItem item in stairPool)
            {
                if (item.YPosition <= offsetYBottom)
                {
                    var frameOvertravel = -item.YPosition + offsetYBottom;

                    if (!shouldEndAsap)
                    {
                        item.YPosition = offsetYTop - frameOvertravel;
                    }
                    else if (!stopped)
                    {
                        item.Dispose();
                        stopped = true;
                        var go = Instantiate(EndStairPrefab, transform);
                        go.transform.localPosition += new Vector3(0, offsetYTop - Speed * Time.deltaTime - frameOvertravel, 0);
                        GameObject.Find("Youmu").GetComponentInChildren<PlayerAnimation>().movementLocked = false;
                        GameObject.Find("Youmu").GetComponentInChildren<PlayerMovement>().movementLocked = false;
                    }
                }
                item.Move(Speed);
            }
        }
    }
    public void Stop()
    {
        shouldEndAsap = true;
    }
    public interface IStairItem
    {
        float YPosition { get; set; }
        float Height { get; }
        void Move(float speed);
        void Dispose();
    }
}
