using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambiarEscena : MonoBehaviour
{
    public void CambiarEcenaClick(string sceneName)
    {
        StartCoroutine(retrasoEscena(sceneName));
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    IEnumerator retrasoEscena(string sceneName)
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneName);
    }
}
