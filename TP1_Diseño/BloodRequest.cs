using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP1_Diseño
{
    public class BloodRequest
    {
        public int amountDonors { get; set; }
        public string dateLimit { get; set; }
        public string bloodGroup { get; set; }
        public string bloodFactor { get; set; }


        public BloodRequest StartRequest()
        {
            BloodRequest bloodRequest = new BloodRequest();
            Console.WriteLine("Ingrese la cantidad de donadores que necesita: ");
            string amountDonors = Console.ReadLine();
            amountDonors = ValdationsBloodRequest.validateAmountDonors(amountDonors);
            bloodRequest.amountDonors = Convert.ToInt32(amountDonors);

            Console.WriteLine("Ingrese la fecha limite para la donación(dd/mm/yyyy): ");
            string dateLimit = Console.ReadLine();
            dateLimit = ValdationsBloodRequest.validateDateBoodRequest(dateLimit);
            bloodRequest.dateLimit = dateLimit;

            Console.WriteLine("Ingrese el grupo sanguineo(A,B,AB,0): ");
            string bloodGroup = Console.ReadLine();
            bloodRequest.bloodGroup = ValdationsBloodRequest.validateBloodGroup(bloodGroup);

            Console.WriteLine("Ingrese el factor sanguineo(+,-): ");
            string bloodFactor = Console.ReadLine();
            bloodRequest.bloodFactor = ValdationsBloodRequest.validateBloodFactor(bloodFactor);


            return bloodRequest;
        }

        public void AssignTurns(List<Partner> partners, BloodRequest bloodRequest)
        {
            List<Partner> _avaliblesPartners = null;
            List<Partner> _selectedPartners = null;
            int contDonations = 0;
            foreach (var partner in partners)
            {
                contDonations = 0;
                foreach (var donation in partner.donations)
                {
                    if (donation.Year == DateTime.Now.Year)
                    {
                        contDonations++;
                    }
                }
                if (contDonations < 2 && partner.category == "ACTIVO")
                {
                    _avaliblesPartners.Add(partner);
                }
            }

            for (int i = 0; i < bloodRequest.amountDonors; i++)
            {
                _selectedPartners.Add(_avaliblesPartners[i]);
            }

            Console.WriteLine("los socios selecionados son: ");
            foreach (var partner in _selectedPartners)
            {
                Console.WriteLine("nombre:", partner.namePartner, " dni:", partner.dni);
            }
            foreach (var partner in _selectedPartners)
            {
                Console.WriteLine("seleccione una de las fechas disponibles para el socio ", partner.dni);

                DateTime dateTemp = DateTime.Now;
                DateTime dateLimit = DateTime.ParseExact(bloodRequest.dateLimit, "dd/mm/yyyy", null);
                while (dateTemp <= dateLimit)
                {
                    Console.WriteLine(dateTemp);
                    dateTemp = dateTemp.AddDays(1);
                }

            }
        }
    }
}
