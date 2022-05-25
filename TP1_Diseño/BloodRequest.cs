using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_Diseño.commos;
using FluentValidation;

namespace TP1_Diseño
{
    public class BloodRequest
    {
        public int amountDonors { get; set; }
        public string dateLimit { get; set; }
        public string bloodGroup { get; set; }
        public EnumBloodFactor bloodFactor { get; set; }


        public BloodRequest StartRequest()
        {
            BloodRequest bloodRequest = new BloodRequest();
            Console.WriteLine("Ingrese la cantidad de donadores que necesita: ");
            string amountDonors = Console.ReadLine();
            amountDonors = Valdations.validateAmountDonors(amountDonors);
            bloodRequest.amountDonors = Convert.ToInt32(amountDonors);  

            Console.WriteLine("Ingrese la fecha limite para la donación(dd/mm/yyyy): ");
            string dateLimit = Console.ReadLine();
            dateLimit = Valdations.validateDateBoodRequest(dateLimit);
            bloodRequest.dateLimit =  dateLimit;

            Console.WriteLine("Ingrese el grupo sanguineo(A,B,AB,0): ");
            string bloodGroup = Console.ReadLine();
            bloodRequest.bloodGroup = Valdations.validateBloodGroup(bloodGroup);

            Console.WriteLine("Ingrese el factor sanguineo(+,-): ");
            string bloodFactor = Console.ReadLine();
            

            return bloodRequest;
        }

        //public void AssignTurns(List<Partner> partners, BloodRequest bloodRequest)
        //{
        //    List<Partner> _avaliblesPartners = null;
        //    List<Partner> _selectedPartners = null;
        //    int contDonations = 0;
        //    foreach (var partner in partners)
        //    {
        //        contDonations = 0;
        //        foreach (var donation in partner.donations)
        //        {
        //            if (donation.Year == DateTime.Now.Year)
        //            {
        //                contDonations++;
        //            }
        //        }
        //        if (contDonations < 2 && partner.category == EnumCategory.ACTIVO)
        //        {
        //            _avaliblesPartners.Add(partner);
        //        }
        //    }

        //    for (int i = 0; i < bloodRequest.amountDonors; i++)
        //    {
        //        _selectedPartners.Add(_avaliblesPartners[i]);
        //    }

        //    Console.WriteLine("Los socios selecionados son: ");
        //    foreach(var partner in _selectedPartners)
        //    {
        //        Console.WriteLine("Nombre:", partner.namePartner, " DNI:", partner.dni);
        //    }
        //    foreach (var partner in _selectedPartners) {
        //        Console.WriteLine("Seleccione una de las fechas disponibles para el socio ", partner.dni);

        //        DateTime fechatemp = DateTime.Now;

        //        while (fechatemp <= bloodRequest.dateLimit)
        //        {
        //            Console.WriteLine(fechatemp);
        //            fechatemp = fechatemp.AddDays(1);
        //        }

        //    }

    }
}
