using UnityEngine;
using UnityEngine.SceneManagement; // 必須引用這個命名空間

public class SceneController : MonoBehaviour
{
    // 用於加載下一個場景
    public void LoadScene(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene); // 加載指定名稱的場景
    }

    // 用於退出遊戲（選擇性）
    public void QuitGame()
    {
        Application.Quit(); // 在編輯器中無效，但打包後能關閉應用程式
        Debug.Log("Game is exiting..."); // 調試用
    }
}
