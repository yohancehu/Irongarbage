using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseUI : MonoBehaviour
{
    public Text context;

    public void SetText(string content)
    {
        context.text = content;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
