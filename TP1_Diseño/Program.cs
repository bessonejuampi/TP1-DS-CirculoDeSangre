using System;
using FluentValidation;
using FluentValidation.Results;

namespace TP1_Diseño
{
    class program
    {
        public static List<Partner> listPartners = new List<Partner>();
        public static List<BloodRequest> listBloodRequest = null;
        static void Main(string[] args)
        {
            starMenu();
        }
        static void starMenu()
        {
            Console.WriteLine(" Elija la opración que desea ejecutar: ");
            Console.WriteLine(" -------------------------------------");
            Console.WriteLine(" 1.Registrar un nuevo socio ");
            Console.WriteLine(" 2.Mostrar datos de un socio ");
            Console.WriteLine(" 3.Cargar una solicitud de donacion y buscar donantes ");
            Console.WriteLine(" -------------------------------------");
            Console.Write("Operacion: ");
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
                    bloodRequest = bloodRequest.StartRequest();
                    starMenu();

                    break;

            }   
        
        
        }
        
    }

    
}
