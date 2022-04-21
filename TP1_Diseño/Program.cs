using System;

namespace TP1_Diseño
{
    class program
    {
        public static List<Partner> listPartners = null;
        static void Main(string[] args)
        {
            starMenu();
        }
        static void starMenu()
        {
        Console.WriteLine("Elija la opración que desea ejecutar: \n");
        Console.WriteLine("------------------------------------- \n");
        Console.WriteLine("1.Registrar un nuevo socio: \n");
        Console.WriteLine("2.Mostrar datos de un socio: \n");

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
        }
        
        
        }
        
    }

    
}
