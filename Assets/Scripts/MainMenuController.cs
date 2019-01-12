using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GameObject.Find("PlayButton").GetComponentInChildren<Button>().onClick.AddListener(() =>
           {
               GetComponent<Animator>().SetBool("uiControlsVisible", false);
               GameObject.Find("EndlessStaircase").GetComponent<EndlessStaircase>().Stop();
               GameObject.Find("Youmu").GetComponentInChildren<PlayerAnimation>().movementLocked = false;
               GameObject.Find("Youmu").GetComponentInChildren<PlayerMovement>().movementLocked = false;
               GameObject.Find("Ghost").GetComponentInChildren<MouseFollow>().Enable();
           });
        GameObject.Find("QuitButton").GetComponentInChildren<Button>().onClick.AddListener(
            () => Application.Quit());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
