using UnityEngine.SceneManagement;

public static class MySceneManager
{
    public static void ChangeScene(string nome)
    {
        SceneManager.LoadScene(nome);
    }
}
