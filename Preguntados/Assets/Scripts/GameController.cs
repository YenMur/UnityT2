using models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    string lineaLeida = "";
    List<PreguntasMultiples> listaPreguntasMultiples;
    List<PreguntasMultiples> listaPreguntasMultiplesFacil;

    string respuestaPM;

    public TextMeshProUGUI textPregunta;
    public TextMeshProUGUI textResp1;
    public TextMeshProUGUI textResp2;
    public TextMeshProUGUI textResp3;
    public TextMeshProUGUI textResp4;
    public TextMeshProUGUI textVersC;
    public TextMeshProUGUI textVersI;
    public TextMeshProUGUI textRespuestaC;

    public GameObject panelCorrecto;
    public GameObject panelIncorrecto;
    public GameObject panelPrincipal;
    public GameObject panelFin;

    public Button continuar;
    


    // Start is called before the first frame update
    void Start()
    {
        listaPreguntasMultiples = new List<PreguntasMultiples>();
        listaPreguntasMultiplesFacil = new List<PreguntasMultiples>();
        LecturaPreguntasMultiples();
        mostrarPreguntasMultiples();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrarPreguntasMultiples()
    {
        panelCorrecto.SetActive(false);
        panelIncorrecto.SetActive(false);
        panelPrincipal.SetActive(true);
        panelFin.SetActive(false);

        

        if (listaPreguntasMultiples.Count > 0)
        {
            int i = UnityEngine.Random.Range(0, listaPreguntasMultiples.Count);

            
                textPregunta.text = listaPreguntasMultiples[i].Pregunta;
                textResp1.text = listaPreguntasMultiples[i].Respuesta1;
                textResp2.text = listaPreguntasMultiples[i].Respuesta2;
                textResp3.text = listaPreguntasMultiples[i].Respuesta3;
                textResp4.text = listaPreguntasMultiples[i].Respuesta4;
                respuestaPM = listaPreguntasMultiples[i].RespuestaCorrecta;
                textVersC.SetText(listaPreguntasMultiples[i].Versiculo);
                textVersI.SetText(listaPreguntasMultiples[i].Versiculo);
                textRespuestaC.SetText("La respuesta correcta es: " + listaPreguntasMultiples[i].RespuestaCorrecta);


                listaPreguntasMultiples.RemoveAt(i);
                listaPreguntasMultiplesFacil.AddRange(listaPreguntasMultiples);
                
            

            
        }
        else
        {
            
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(false);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(true);
            
        }

        
    }

    public void cerrarQuiz()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
            
    }

    public void comprobarRespuesta1()
    {
        if (textResp1.text.Equals(respuestaPM))
        {
            Debug.Log("Respuesta Correcta es la 1");

            panelCorrecto.SetActive(true);
            panelIncorrecto.SetActive(false);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
            

        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 1");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
        }
    }

    public void comprobarRespuesta2()
    {
        if (textResp2.text.Equals(respuestaPM))
        {
            Debug.Log("Respuesta Correcta es la 2");
            panelCorrecto.SetActive(true);
            panelIncorrecto.SetActive(false);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 2");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
        }
    }

    public void comprobarRespuesta3()
    {
        if (textResp3.text.Equals(respuestaPM))
        {
            Debug.Log("Respuesta Correcta es la 3");
            panelCorrecto.SetActive(true);
            panelIncorrecto.SetActive(false);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 3");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
        }
    }

    public void comprobarRespuesta4()
    {
        if (textResp4.text.Equals(respuestaPM))
        {
            Debug.Log("Respuesta Correcta es la 4");
            panelCorrecto.SetActive(true);
            panelIncorrecto.SetActive(false);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
        }
        else
        {
            Debug.Log("Respuesta Incorrecta es la 4");
            panelCorrecto.SetActive(false);
            panelIncorrecto.SetActive(true);
            panelPrincipal.SetActive(false);
            panelFin.SetActive(false);
        }
    }

    #region Lectura archivos
    public void LecturaPreguntasMultiples()
    {
        try
        {
            StreamReader srl = new StreamReader("Assets/Files/ArchivoPreguntasM.txt");
            while((lineaLeida=srl.ReadLine()) != null)
            {
                string[] lineaPartida = lineaLeida.Split("-");
                string pregunta = lineaPartida[0];
                string respuesta1 = lineaPartida[1];
                string respuesta2 = lineaPartida[2];
                string respuesta3 = lineaPartida[3];
                string respuesta4 = lineaPartida[4];
                string respuestaCorrecta = lineaPartida[5];
                string versiculo = lineaPartida[6];
                string dificultad = lineaPartida[7];

                PreguntasMultiples objPM = new PreguntasMultiples(pregunta, respuesta1, respuesta2,
                    respuesta3, respuesta4, respuestaCorrecta, versiculo, dificultad);

                listaPreguntasMultiples.Add(objPM);

                if (dificultad.Equals("facil"))
                {
                    listaPreguntasMultiplesFacil.Add(objPM);
                }
            }
            Debug.Log("El tamaño de lista es " + listaPreguntasMultiples.Count);

        }
        catch(Exception e)
        {
            Debug.Log("ERROR!!!!" + e.ToString());
        }
        finally
        {
            Debug.Log("Executing finally block.");
        }
        
    }
    #endregion
}
