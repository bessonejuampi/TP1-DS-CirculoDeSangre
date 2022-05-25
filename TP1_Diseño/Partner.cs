using System.Collections;
using System.ComponentModel;
using TP1_Diseño.commos;
using FluentValidation;

namespace TP1_Diseño;

public class Partner
{
    public string namePartner { get; set;}
    private string lastNamePartner { get; set; }
    public int dni { get; set; }
    public EnumCategory category { get; set; }
    private bool disease { get; set; }
    private bool medicine { get; set; }
    private string nameMedicine { get; set; }
    private string dateBrith { get; set; }
    private string home { get; set; }
    private string location { get; set; }
    private string phone { get; set; }
    private string email { get; set; }
    private EnumBloodGroup bloodGroup { get; set; }
    private string bloodFactor { get; set; }
    public List<DateTime> donations { get; set; }
    

    void getData()
    {
        Console.WriteLine("Nombre: " + namePartner + "Apellido: " + lastNamePartner + "DNI: " + dni);
    }

    public Partner registerPartner()
    {
        Partner partner = new Partner();
        
        Console.WriteLine("Ingrese el nombre del socio: ");
        partner.namePartner = Console.ReadLine();
        
        Console.WriteLine("Ingrese el apellido del socio: ");
        partner.lastNamePartner = Console.ReadLine();
        
        Console.WriteLine("Ingrese el dni del socio: ");
        partner.dni = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el la fecha de namcimiento del socio(dd/MM/yyyy): ");
        partner.dateBrith = Console.ReadLine();

        if (calculateAge(partner.dateBrith) > 18 && calculateAge(partner.dateBrith) < 57)
        {
            partner.category = EnumCategory.ACTIVO;
        }
        else
        {
            partner.category = EnumCategory.PASIVO;
        }
        
        Console.WriteLine("¿Padece alguna enferedad cronica?(1= SI, 2=NO): ");
        int disease = Convert.ToInt32(Console.ReadLine());
        if (disease == 1)
        {
            partner.disease = true;
            partner.category = EnumCategory.PASIVO;
        }
        else
        {
            partner.disease = false;
        }
        
        Console.WriteLine("¿Toma alguna medicina de forma permanente?(1= SI, 2=NO): ");
        int medicine = Convert.ToInt32(Console.ReadLine());
        if (medicine == 1)
        {
            partner.medicine = true;
            Console.WriteLine("Ingrese el nombre de la medicina: ");
            partner.nameMedicine = Console.ReadLine();
        }
        else
        {
            partner.medicine = false;
            partner.nameMedicine = null;
        }
        
        Console.WriteLine("Ingrese la direccion del socio: ");
        partner.home = Console.ReadLine();
        
        Console.WriteLine("Ingrese la localidad del socio: ");
        partner.location = Console.ReadLine();
        
        Console.WriteLine("Ingrese el telefono del socio: ");
        partner.phone = Console.ReadLine();
        
        Console.WriteLine("Ingrese el emial del socio: ");
        partner.email = Console.ReadLine();
        do
        {
            Console.WriteLine("Ingrese el grupo sanguineo del socio: ");
            string bloodGroup = Console.ReadLine();
            if (bloodGroup == "a" || bloodGroup == "A")
            {
                partner.bloodGroup = EnumBloodGroup.A;
            }
            else if (bloodGroup == "b" || bloodGroup == "B")
            {
                partner.bloodGroup = EnumBloodGroup.B;
            }
            else if (bloodGroup == "ab" || bloodGroup == "AB")
            {
                partner.bloodGroup = EnumBloodGroup.AB;
            }
            else if (bloodGroup == "0" || bloodGroup == "CERO" || bloodGroup == "cero")
            {
                partner.bloodGroup = EnumBloodGroup.CERO;
            }
        } while (partner.bloodGroup!= null);

        Console.WriteLine("Ingrese el factor sanguineo del socio: ");
        partner.bloodFactor = Console.ReadLine();
        
        return partner;
    }
    public  double calculateAge(string dateBrithString)
    {
        DateTime dateBrithDate = DateTime.Now;
        try
        {
            dateBrithDate = DateTime.ParseExact(dateBrithString, "dd/MM/yyyy", null);
        }
        catch (Exception e)
        {
            Console.WriteLine("Escriba la fecha de nacimiento en el formato correcto");
        }
        DateTime dateCurret = DateTime.Now;

        TimeSpan difference = dateCurret - dateBrithDate;
        double days = difference.TotalDays;
        double years = Math.Floor(days / 365);
        return years; 
    }
    
    public Partner UpdateCategory(Partner partner)
    { 
        double years= calculateAge(partner.dateBrith);
        if (years > 18 && years < 57)
        {
            partner.category = EnumCategory.ACTIVO;
        }
        else
        {
            partner.category = EnumCategory.PASIVO;
        }
        return partner;
    }

    
}

public class PartnerVañidator : AbstractValidator<Partner>
{
    //LessThan(BloodRequest => DateTime.Now) Prara quesea menor a la fecha actual 
    // .Must(BeAValidAge).WithMessage("Invalid {PropertyName}");
    //protected bool BeAValidAge(DateTime date)
    //{
    //    int currentYear = DateTime.Now.Year;
    //    int dobYear = date.Year;

    //    if (dobYear <= currentYear && dobYear > (currentYear - 120))
    //    {
    //        return true;
    //    }

    //    return false;
    //}

}


