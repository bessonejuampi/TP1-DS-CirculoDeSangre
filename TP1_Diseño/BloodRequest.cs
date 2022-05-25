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
        public DateTime dateLimit { get; set; }
        public EnumBloodGroup bloodGroup { get; set; } 
        public EnumBloodFactor bloodFactor { get; set; }


        public BloodRequest StartRequest()
        {
            BloodRequest bloodRequest = new BloodRequest();
            Console.WriteLine("Ingrese la cantidad de donadores que necesita: ");
            bloodRequest.amountDonors= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha limite para la donación(dd/mm/yyyy): ");
            string dateLimit = Console.ReadLine();
            bloodRequest.dateLimit = DateTime.ParseExact(dateLimit, "dd/MM/yyyy", null);

            Console.WriteLine("Ingrese el grupo sanguiñeo: ");
            string bloodGroup = Console.ReadLine();
            if (bloodGroup == "a" || bloodGroup == "A")
            {
                bloodRequest.bloodGroup = EnumBloodGroup.A;
            }
            else if (bloodGroup == "b" || bloodGroup == "B")
            {
                bloodRequest.bloodGroup = EnumBloodGroup.B;
            }
            else if (bloodGroup == "ab" || bloodGroup == "AB")
            {
                bloodRequest.bloodGroup = EnumBloodGroup.AB;
            }
            else if (bloodGroup == "0" || bloodGroup == "CERO" || bloodGroup == "cero")
            {
                bloodRequest.bloodGroup = EnumBloodGroup.CERO;
            }

            Console.WriteLine("Ingrese el factor sanguiñeo: ");
            string bloodFactor = Console.ReadLine();
            if(bloodFactor == "+")
            {
                bloodRequest.bloodFactor = EnumBloodFactor.POSITIVO;
            }
            else
            {
                bloodRequest.bloodFactor = EnumBloodFactor.NEGATIVO;
            }

            return bloodRequest;
        }

        
    }
    public class BloodRequestValidator : AbstractValidator<BloodRequest>
    {
        public BloodRequestValidator()
        {
            RuleFor(bloodRequest => bloodRequest.amountDonors)
                .NotNull()
                .NotEmpty();
            RuleFor(bloodRequest => bloodRequest.dateLimit)
                .NotNull()
                .GreaterThan(BloodRequest => DateTime.Now);
            RuleFor(bloodRequest => bloodRequest.bloodGroup)
                .NotNull()
                .NotEmpty();
        }

       
    }
}
