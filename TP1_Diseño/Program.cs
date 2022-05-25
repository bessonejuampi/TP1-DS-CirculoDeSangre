using System;
using FluentValidation;
using FluentValidation.Results;

namespace TP1_Diseño
{
    class program
    {
        public static List<Partner> listPartners = null;
        public static List<BloodRequest> listBloodRequest = null;
        static void Main(string[] args)
        {
            starMenu();
        }
        static void starMenu()
        {
        Console.WriteLine("\n Elija la opración que desea ejecutar: ");
        Console.WriteLine("\n -------------------------------------");
        Console.WriteLine("\n 1.Registrar un nuevo socio: ");
        Console.WriteLine("\n 2.Mostrar datos de un socio: ");
        Console.WriteLine("\n 3.Cargar una solicitud de donacion: ");

            int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
                case 1:
                option = 1;
                Partner newpartner = new Partner();
                newpartner = newpartner.registerPartner();
                listPartners.Add(newpartner);
                Console.WriteLine("¡Nuevo socio registrado!");
                starMenu();
                    break;

                case 2:
                    option = 2;
                    break;

                case 3:
                    option = 3;
                    BloodRequest bloodRequest = new BloodRequest();
                    bloodRequest= bloodRequest.StartRequest();
                    BloodRequestValidator validator = new BloodRequestValidator();
                    ValidationResult results = validator.Validate(bloodRequest);
                    if (!results.IsValid)
                    {
                        foreach (var failure in results.Errors)
                        {
                            Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                        }
                    }
                    else
                    { 
                        listBloodRequest.Add(bloodRequest);
                    }

                    break;

        }
        
        
        }
        
    }

    
}
