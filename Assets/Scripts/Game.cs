using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Dificultad[] bancoPreguntas;
    public TextMeshProUGUI enunciado;
    public TextMeshProUGUI[] respuestas;
    public int nivelPregunta;
    public Preguntas preguntaActual;
    public PanelComplementario panelComplementario;
    public Button[] btnRespuesta;
    // Start is called before the first frame update
    void Start()
    {
        nivelPregunta = 0;
        cargarBancoPreguntas();
        setPregunta();
    }

    public void setPregunta()
    {
        int preguntaRandom = 
            Random.Range(0, bancoPreguntas[nivelPregunta].preguntas.Length);
        preguntaActual = 
            bancoPreguntas[nivelPregunta].preguntas[preguntaRandom];
        enunciado.text = preguntaActual.enunciado;
        for (int i = 0; i < respuestas.Length; i++)
        {
            respuestas[i].text = preguntaActual.respuestas[i].texto;

        }


    }
    public void cargarBancoPreguntas()
    {
        try
        {
            bancoPreguntas = 
                JsonConvert.
                DeserializeObject<Dificultad[]>(File.
                ReadAllText(Application.streamingAssetsPath + 
                "/QuestionBank.json"));

        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
    public void evaluarPregunta(int respuestaJugador)
    {
        if (respuestaJugador == preguntaActual.respuestaCorrecta)
        {
            nivelPregunta++;
            if (nivelPregunta == bancoPreguntas.Length)
            {
                SceneManager.LoadScene("Gane");
            }
            else
            {
                try
                {
                    panelComplementario.desplegar();
                }
                catch (System.Exception ex)
                {
                    Debug.Log("Olvidaste configurar el panel complementario:" + ex.Message);
                }
            }
        }
        else
        {
            SceneManager.LoadScene("Perdida");
        }

    }
}
