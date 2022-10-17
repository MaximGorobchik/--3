using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Car
{
    public string model;
    public Engine engine;
    public Cargo cargo;
    public Tires[] tire;

    public Car(string model, Engine engine, Cargo cargo)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tire = new Tires[4];
    }
}

public class Engine
{
    public int EngineSpeed;
    public int EnginePower;
    public Engine(int EngineSpeed, int EnginePower)
    {
        this.EnginePower = EnginePower;
        this.EngineSpeed = EngineSpeed;
    }
}

public class Cargo
{
    public int CargoWeight;
    public string CargoType;
    public Cargo(int cargoWeight, string cargoType)
    {
        this.CargoWeight = cargoWeight;
        this.CargoType = cargoType;
    }
}

public class Tires
{
    public double TirePressure;
    public int TireAge;
    public Tires(double tirePressure, int tireAge)
    {
        this.TirePressure = tirePressure;
        this.TireAge = tireAge;
    }
}

namespace Problem_8.Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ci = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            ci.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = ci;
            Console.Write("How many cars u wanna input?: ");
            var n = int.Parse(Console.ReadLine());
            var car = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                Console.Write("Car #" + (i+1) + ": ");
                var CarInfo = Console.ReadLine().Split();
                var model = CarInfo[0];
                var enginespeed = int.Parse(CarInfo[1]);
                var enginepower = int.Parse(CarInfo[2]);
                var cargoweight = int.Parse(CarInfo[3]);
                var cargtype = CarInfo[4];

                var engine = new Engine(enginespeed, enginepower);
                var cargo = new Cargo(cargoweight, cargtype);

                var tires = new Tires[4];
                var tirescounter = 0;
                for (int j =0;j<8;j+=2)
                {
                    var tirePressure = double.Parse(CarInfo[5 + j]);
                    var tireAge = int.Parse(CarInfo[6 + j]);
                    var currentTire = new Tires(tirePressure, tireAge);
                    tires[tirescounter] = currentTire;
                    tirescounter++;
                }
                var cars = new Car(model, engine, cargo);
                cars.tire = tires;
                car.Add(cars);
            }
            var res = new List<Car>();

            var cargotype = Console.ReadLine();
            if (cargotype.Equals("fragile"))
            {
                res = car.Where(c => c.cargo.Equals("fragile") && c.tire.Any(t => t.TirePressure < 1)).ToList();
            }
            else
            {
                res = car.Where(c => c.cargo.Equals("flamable") && c.engine.EnginePower > 250).ToList();
            }

            foreach (var cars in res)
            {
                Console.WriteLine(cars.model);
            }
        }
    }
}
