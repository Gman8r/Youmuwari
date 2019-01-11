using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StairItem : MonoBehaviour, EndlessStaircase.IStairItem
{
    public float YPosition
    {
        get
        {
            return transform.localPosition.y;
        }

        set
        {
            transform.localPosition = new Vector3(transform.localPosition.x, value, transform.localPosition.z);
        }
    }

    public float Height
    {
        get
        {
            return sprite.bounds.size.y;
        }
    }

    private SpriteRenderer sprite;

    public void Dispose()
    {
        gameObject.SetActive(false);
    }

    //Intended
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Move(float speed)
    {
        transform.localPosition += new Vector3(0, -speed * Time.deltaTime, 0);
    }
}
