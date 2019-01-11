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
           });
        GameObject.Find("QuitButton").GetComponentInChildren<Button>().onClick.AddListener(
            () => Application.Quit());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
