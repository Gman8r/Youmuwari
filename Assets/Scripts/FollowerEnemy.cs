using UnityEngine;

[RequireComponent(typeof(PointFollow))]
public class FollowerEnemy : MonoBehaviour
{
    public enum State { PLAYER, IDLE, CAKE }
    public State CurrentState = State.IDLE;

    public GameObject cake;

    public PointFollow pointFollow;
    private PlayerMovement playerMovement;
    public Animator animator;
    public Animator fadeAnimator;

    // Use this for initialization
    void Start()
    {
        pointFollow = GetComponent<PointFollow>();
        playerMovement = GameObject.Find("Youmu").GetComponent<PlayerMovement>();
        fadeAnimator = GetComponent<Animator>();
        animator = transform.Find("Rig").GetComponent<Animator>();

        CurrentState = State.IDLE;
    }

    public void ResetState(State state)
    {
        if (CurrentState == state) return;

        CurrentState = state;
        if (CurrentState == State.IDLE)
        {
            pointFollow.ProvideTarget = null;
        }
        else if (CurrentState == State.PLAYER)
        {
            animator.SetTrigger("lulw");
            pointFollow.ProvideTarget = () => playerMovement.transform.position;
        }
        else if (CurrentState == State.CAKE)
        {
            if (cake == null) return;
            pointFollow.ProvideTarget = () => cake.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



    void EatCake()
    {
        //PlayAnim
        //teleport
        //Play again
    }
}
