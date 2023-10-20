public class Tax
{
    protected int id;
    protected int years;
    protected int salary;
    protected double podatok;

    public Tax (int id,int years, int salary)
    {
        this.id = id;
        this.years = years;
        this.salary = salary;
    }

    public void Print()
    {
        Console.WriteLine($"ID: {id}, народився в {years} р., дохiд: {salary}, податок: {podatok}");
    }
    virtual public double CalculateTax()
    {
        Console.WriteLine("Звичайний платник податкiв");
        int age = 2023 - years;
        if (age < 17 || salary < 1000)
        {
            podatok = 0;
        }
        else if (salary >= 1000 && salary <= 10000)
        {
            podatok = Math.Round(0.2 * salary, 2);
        }
        else
        {
            podatok = Math.Round(0.25 * salary, 2);
        }
        return podatok;
    }
}
public class Privilege : Tax
{
    public bool priv;
    public Privilege (int id, int years, int salary, bool pr) : base (id, years, salary)
    {
        this.priv = pr;
    }

    override public double CalculateTax()
    {
        Console.WriteLine("Пiльговик");
        int age = 2023 - years;
        if (age < 17 || salary < 10000)
        {
            podatok = 0;
        }
        else if (salary >= 10000 && salary <= 50000)
        {
            podatok = Math.Round(0.1 * salary, 2);
        }
        else
        {
            podatok = Math.Round(0.2 * salary, 2);
        }
        return podatok;
    }
}

class Public
{
    static void Main(string[] args)
    {
        Random o = new Random();
        for (int i = 0; i < 3; i++)
        {
            int id = o.Next(1000, 10000);
            int years = o.Next(1938, 2023);
            int salary = o.Next(0, 100000);
            bool privilege;
            int rand = o.Next(0, 2);
            if (rand == 1)
            {
                privilege = true;
            }
            else
            {
                privilege = false;
            }

            Tax t;
            if (privilege)
            {
                t = new Privilege(id, years, salary, privilege);
            }
            else
            {
                t = new Tax(id, years, salary);
            }
            t.CalculateTax();
            t.Print();
            Console.WriteLine(" ");
        }
    }
}