using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalTrainerScript : MonoBehaviour
{
    enum Entrenamientos
    {
        Cardio = 1000,
        Fuerza = 1500,
        Recreativo = 2500,
    }

    public int horasReservadas;
    [field: SerializeField] private Entrenamientos eChosen;

    bool ValidateData()
    {
        if (horasReservadas > 6 || horasReservadas < 0)
        {
            print("El numero de horas elegidas es invalido, tienen que ser menor a 6 o mayor a 0");
            return false;
        }

        if (eChosen != Entrenamientos.Cardio &&
            eChosen != Entrenamientos.Fuerza &&
            eChosen != Entrenamientos.Recreativo)
        {
            print("Porfavor elegir un entrenamiento valido.");
            return false;
        }
        return true;
    }

    private void Start()
    {
        if (!ValidateData())
        {
            return;
        }
    }
}
