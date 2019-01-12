using UnityEngine;

[RequireComponent(typeof(PointFollow))]
public class FollowerEnemy : MonoBehaviour
{
    public enum State { ACTIVE, IDLE }
    private State _currentState = State.IDLE;
    public State CurrentState
    {
        get { return _currentState; }
        set
        {
            if (value == _currentState)
                return;

            _currentState = value;
            if (_currentState == State.ACTIVE)
            {
                pointFollow.IsFollowing = true;
            }
            else
            {
                pointFollow.IsFollowing = false;
            }
        }
    }

    public PointFollow pointFollow;
    private PlayerMovement playerMovement;

    // Use this for initialization
    void Start()
    {
        pointFollow = GetComponent<PointFollow>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        pointFollow.ProvideTarget = () => playerMovement.transform.position;
        CurrentState = State.IDLE;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RespawnAt(Vector3 position)
    {
        //PlayAnim
        //teleport
        //Play again
    }
}
