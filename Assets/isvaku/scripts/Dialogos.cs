using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public TMP_Text m_TextComponent;

    void JefeSpeakLost()
    {

        int fraseNum = Random.Range(1, 20);
        string frase = "";



        switch (fraseNum)
        {
            case 1:
                frase = "¿No huele un poco raro aquí?";
                break;
            case 2:
                frase = "He visto gente más rápida en un asilo de ancianos";
                break;
            case 3:
                frase = "¿Estas nervioso?";
                break;
            case 4:
                frase = "¿Me entiendes?";
                break;
            case 5:
                frase = "¿Tienes experiencia en un puesto similar?";
                break;
            case 6:
                frase = "¡Mirame cuando te hablo!";
                break;
            case 7:
                frase = "¿Necesitas el dinero de verdad?";
                break;
            case 8:
                frase = "Las palabras se las lleva el viento como tu curriculum";
                break;
            case 9:
                frase = "¡INCOMPETENTE!";
                break;
            case 10:
                frase = "¿Que estas haciendo?";
                break;
            case 11:
                frase = "!FALTA PORFOLIO!";
                break;
            case 12:
                frase = "!DEBES MEJORAR!";
                break;
            case 13:
                frase = "Si no me haces caso verás";
                break;
            case 14:
                frase = "¿Me estas mirando a mi o al infinito?";
                break;
            case 15:
                frase = "¿No puedes hacerlo mejor?";
                break;
            case 16:
                frase = "¿Disfrutas de las vistas?";
                break;
            case 17:
                frase = "Si no te gusta hay más gente esperando en la cola del paro";
                break;
            case 18:
                frase = "¿Que problema tienes?";
                break;
            case 19:
                frase = "!No me hagas perder el tiempo!";
                break;
            case 20:
                frase = "¿Que hacemos aquí?";
                break;

        }



        m_TextComponent.text = frase;

    }
    private void Start()
    {

        void EmployerSpeakLost()
        {

            int fraseNum = Random.Range(1, 20);
            string frase = "";
            switch (fraseNum)
            {
                case 1:
                    frase = "Lo siento";
                    break;
                case 2:
                    frase = "No se la respuesta";
                    break;
                case 3:
                    frase = "No entiendo nada de eso";
                    break;
                case 4:
                    frase = "No se que responderte";
                    break;
                case 5:
                    frase = "¿Puedes repetir la pregunta?";
                    break;
                case 6:
                    frase = "¿Que has dicho?";
                    break;
                case 7:
                    frase = "No puedo hacer eso";
                    break;
                case 8:
                    frase = "Eso no seria cortés";
                    break;
                case 9:
                    frase = "¡INCONCEDIBLE!";
                    break;
                case 10:
                    frase = "Puedo intentarlo";
                    break;
                case 11:
                    frase = "Me falta experiencia en ese campo";
                    break;
                case 12:
                    frase = "Me acabo de distraer, dimelo de nuevo";
                    break;
                case 13:
                    frase = "Siento que no seré capaz de hacer eso";
                    break;
                case 14:
                    frase = "¡Cuando me tocas tocas el infinito, pero no me toques!";
                    break;
                case 15:
                    frase = "No se de que me hablas";
                    break;
                case 16:
                    frase = "No entiendo esto";
                    break;
                case 17:
                    frase = "Creo que es un fallo más que un acierto";
                    break;
                case 18:
                    frase = "No es mi P.O.T.E.N.C.I.A principal";
                    break;
                case 19:
                    frase = "Esto no es sostenible";
                    break;
                case 20:
                    frase = "No tengo una buena experiencia con mi ultimo puesto";
                    break;

            }
            m_TextComponent.text = frase;
        }
        void JefeSpeakWin()
        {

            int fraseNum = Random.Range(1, 20);
            string frase = "";
            switch (fraseNum)
            {
                case 1:
                    frase = "¿Puedes contarme más?";
                    break;
                case 2:
                    frase = "Sigue así, vas muy bien";
                    break;
                case 3:
                    frase = "Eso esta muy bien";
                    break;
                case 4:
                    frase = "MUY BIEN";
                    break;
                case 5:
                    frase = "Veo que has practicado";
                    break;
                case 6:
                    frase = "Que labia tienes";
                    break;
                case 7:
                    frase = "Interesante, sigue";
                    break;
                case 8:
                    frase = "MOLT BE XIQUET";
                    break;
                case 9:
                    frase = "Me gusta tu forma de pensar";
                    break;
                case 10:
                    frase = "Me gusta tu forma de pensar";
                    break;
                case 11:
                    frase = "Las entrevistas como estas, dan gusto";
                    break;
                case 12:
                    frase = "Vamos con la siguiente";
                    break;
                case 13:
                    frase = "Si, suena bien";
                    break;
                case 14:
                    frase = "¡Que buen profesional!";
                    break;
                case 15:
                    frase = "Las personas como tu faltan";
                    break;
                case 16:
                    frase = "Que amable por tu parte";
                    break;
                case 17:
                    frase = "!Que buen trabajo!";
                    break;
                case 18:
                    frase = "Se nota tu valentia";
                    break;
                case 19:
                    frase = "!Pero que productivo!";
                    break;
                case 20:
                    frase = "Sí, que interesante";
                    break;

            }
            m_TextComponent.text = frase;
        }

        void EmployerSpeakWin()
        {

            int fraseNum = Random.Range(1, 20);
            string frase = "";
            switch (fraseNum)
            {
                case 1:
                    frase = "PUEDO HACERLO";
                    break;
                case 2:
                    frase = "PUEDO LOGRARLO";
                    break;
                case 3:
                    frase = "LA RESPUESTA ES SI PUEDO";
                    break;
                case 4:
                    frase = "LO HARE";
                    break;
                case 5:
                    frase = "TE LO DEMOSTRARÉ CON MIS HECHOS";
                    break;
                case 6:
                    frase = "PUEDO LOGRARLO";
                    break;
                case 7:
                    frase = "TE DIRE UNA PALABRA P.O.T.E.N.C.I.A";
                    break;
                case 8:
                    frase = "EL DOLOR DESAPARECE, EL ORGULLO NO";
                    break;
                case 9:
                    frase = "TENGO QUE ESTAR EN ESTA EMPRESA POR QUE ME ENCANTA";
                    break;
                case 10:
                    frase = "ME GUSTA LA ZONA Y CONOZCO A MIS CLIENTES";
                    break;
                case 11:
                    frase = "PODRE HACERLO CON TIEMPO Y DEDICACIÓN";
                    break;
                case 12:
                    frase = "LO HARÉ";
                    break;
                case 13:
                    frase = "CON ESFUERZO Y DEDICACIÓN TODO ES POSIBLE";
                    break;
                case 14:
                    frase = "VOY HA CONSEGUIRLO";
                    break;
                case 15:
                    frase = "SOY UN PROFESIONAL";
                    break;
                case 16:
                    frase = "SOY UN EXPERTO";
                    break;
                case 17:
                    frase = "SOY ADMIN";
                    break;
                case 18:
                    frase = "LO TENGO TODO BAJO CONTROL";
                    break;
                case 19:
                    frase = "LA RESPUESTA CORTA ES SI";
                    break;
                case 20:
                    frase = "LA RESPUESTA ESTA EN TU INTERIOR";
                    break;

            }
            m_TextComponent.text = frase;
        }
        void JefeAnswer()
        {

            int fraseNum = Random.Range(1, 20);
            string frase = "";
            switch (fraseNum)
            {
                case 1:
                    frase = "¿Tienes experiencia en el sector?";
                    break;
                case 2:
                    frase = "¿Que puedes aportar a esta empresa?";
                    break;
                case 3:
                    frase = "Hablame de tu ultimo puesto";
                    break;
                case 4:
                    frase = "¿Que esperas de esta empresa?";
                    break;
                case 5:
                    frase = "¿Que tecnologías controlas?";
                    break;
                case 6:
                    frase = "¿Que tal trabajas en equipo?";
                    break;
                case 7:
                    frase = "¿Con que animal te identificas?";
                    break;
                case 8:
                    frase = "¿Que puedes hacer por la empresa?";
                    break;
                case 9:
                    frase = "¿Con que insecto te identificas?";
                    break;
                case 10:
                    frase = "Dime tus puntos débiles";
                    break;
                case 11:
                    frase = "¿Como puedes ayudar a esta empresa?";
                    break;
                case 12:
                    frase = "¿Por que te gusta nuestra empresa?";
                    break;
                case 13:
                    frase = "¿Que habilidades blandas tienes?";
                    break;
                case 14:
                    frase = "¿Que habilidades tienes?";
                    break;
                case 15:
                    frase = "¿Como podemos ayudarte profesionalmente?";
                    break;
                case 16:
                    frase = "¿Que formación te gustaria recibir?";
                    break;
                case 17:
                    frase = "Hablame de tus aptitudes";
                    break;
                case 18:
                    frase = "Cuentame tu historia";
                    break;
                case 19:
                    frase = "¿Podrias resumir en 20 palabras tu vida laboral?";
                    break;
                case 20:
                    frase = "Si un idiota habla en el bosque ¿hace ruido?";
                    break;

            }
            m_TextComponent.text = frase;
        }

    }
}
