using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelComplementario : MonoBehaviour
{
    public GameObject panelComplementario;
    public Game game;
    public void continuar()
    {
        panelComplementario.SetActive(false);
        game.setPregunta(); 

    }
    public void desplegar()
    {
        panelComplementario.SetActive(true);
    }
}
