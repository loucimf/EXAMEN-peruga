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



    #region Variables
    public int horasReservadas;
    [field: SerializeField] private Entrenamientos eChosen;

    private int _totalPlataDiscount;
    private int _totalPlata;

    private int _plataPorHoraCardio = (int)Entrenamientos.Cardio;
    private int _plataPorHoraRecreativo = (int)Entrenamientos.Recreativo;
    private int _plataPorHoraFuerza = (int)Entrenamientos.Fuerza;
    private int _plataPorHora;
    #endregion



    bool ValidateData()
    {
        if (horasReservadas > 6 || horasReservadas < 1)
        {
            print("El numero de horas elegidas es invalido, tienen que ser menor a 6 o igual/mayor a 1");
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

    int ApplyDiscount(int value)
    {
        print("Se aplico un descuento del 10% por reservar 6 horas!");
        int result = value * 10 / 100;
        return result;
    }

    void ProcessData()
    {

        if (eChosen == Entrenamientos.Cardio)
        {
            _plataPorHora = _plataPorHoraCardio;
        }

        if (eChosen == Entrenamientos.Fuerza)
        {
            _plataPorHora = _plataPorHoraFuerza;
        }

        if (eChosen == Entrenamientos.Recreativo)
        {
            _plataPorHora = _plataPorHoraRecreativo;
        }

        _totalPlata = _plataPorHora * horasReservadas;
        
        if (horasReservadas == 6)
        {
            _totalPlataDiscount = ApplyDiscount(_totalPlata);
            print("El total de dinero de tu entrenamiento de tipo " + eChosen + " CON DESCUENTO es de: " + _totalPlataDiscount + "!");
        }
    }

    private void Start()
    {
        if (!ValidateData())
        {
            return;
        }

        ProcessData();

        print("El total de dinero de tu entrenamiento de tipo " + eChosen + " SIN DESCUENTO es de: " + _totalPlata + "!");
    }
}
