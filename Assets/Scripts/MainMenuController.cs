using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    Animator animator;
    Animator lossAnimator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        lossAnimator = transform.Find("LossMenu").GetComponent<Animator>();

        GameObject.Find("PlayButton").GetComponentInChildren<Button>().onClick.AddListener(() =>
           {
               animator.SetBool("uiControlsVisible", false);
               GameObject.Find("EndlessStaircase").GetComponent<EndlessStaircase>().Stop();
               GameObject.Find("Ghost").GetComponentInChildren<MouseFollow>().Enable();
           });
        GameObject.Find("QuitButton").GetComponentInChildren<Button>().onClick.AddListener(
            () => Application.Quit());

        GameObject.Find("RetryButton").GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            GameObject.Find("Levels").GetComponent<GameController>().OnRetry();
            lossAnimator.SetBool("lossControlsVisible", false);
        });
        GameObject.Find("MenuButton").GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            GlobalReset();
            lossAnimator.SetBool("lossControlsVisible", false);
        });
    }

    public void OnLoss()
    {
        respLocked = true;
        Invoke("unlockResp", 2.1f);
        lossAnimator.SetBool("lossControlsVisible", true);
    }
    bool respLocked = false;
    public void unlockResp()
    {
        respLocked = true;
    }

    public static void GlobalReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
