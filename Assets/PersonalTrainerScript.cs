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
    [Header("Variables")]
    public int horasReservadas;
    [field: SerializeField] private Entrenamientos entrenamientoElegido;

    private int _totalPlataDiscount;
    private int _totalPlata;

    private int _plataPorHoraCardio = (int)Entrenamientos.Cardio;
    private int _plataPorHoraRecreativo = (int)Entrenamientos.Recreativo;
    private int _plataPorHoraFuerza = (int)Entrenamientos.Fuerza;
    private int _plataPorHora;
    #endregion

    #region Helper funcs
    bool ValidateData()
    {
        if (horasReservadas > 6 || horasReservadas < 1)
        {
            print("El numero de horas elegidas es invalido, tienen que ser menor a 6 o igual/mayor a 1");
            return false;
        }

        if (entrenamientoElegido != Entrenamientos.Cardio &&
            entrenamientoElegido != Entrenamientos.Fuerza &&
            entrenamientoElegido != Entrenamientos.Recreativo)
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
        result = _totalPlata - result;
        return result;
    }

    void ChoosePerHourCharge()
    {
        if (entrenamientoElegido == Entrenamientos.Cardio)
        {
            _plataPorHora = _plataPorHoraCardio;
        }

        if (entrenamientoElegido == Entrenamientos.Fuerza)
        {
            _plataPorHora = _plataPorHoraFuerza;
        }

        if (entrenamientoElegido == Entrenamientos.Recreativo)
        {
            _plataPorHora = _plataPorHoraRecreativo;
        }
    }

    void ProcessData()
    {
        ChoosePerHourCharge();

        _totalPlata = _plataPorHora * horasReservadas;
        
        if (horasReservadas == 6)
        {
            _totalPlataDiscount = ApplyDiscount(_totalPlata);
            print("El total de dinero de tu entrenamiento de tipo " + entrenamientoElegido + " CON DESCUENTO es de: " + _totalPlataDiscount + "!");
        }
    }
    #endregion

    private void Start()
    {
        if (!ValidateData())
        {
            return;
        }

        ProcessData();

        print("El total de dinero de tu entrenamiento de tipo " + entrenamientoElegido + " SIN DESCUENTO es de: " + _totalPlata + "!");
    }
}
