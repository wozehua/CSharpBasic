using System;
using System.Collections.Generic;
using System.Text;

namespace DeletegateExample
{
    class CarInfoEventArgs
    {
        public string Car { get; set; }
        public CarInfoEventArgs(string car)
        {
            Car = car;
        }
    }

    class CarDealer
    {
        /// <summary>
        /// EventHandler 泛型委托
        /// </summary>
        public event EventHandler<CarInfoEventArgs> NewCarInfo;

        public void NewCar(string car)
        {
            Console.WriteLine($"CarDealer,new car{car}");
            NewCarInfo?.Invoke(this, new CarInfoEventArgs(car));
        }
    }
}
