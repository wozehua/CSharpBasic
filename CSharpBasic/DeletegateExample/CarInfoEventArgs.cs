using System;
using System.Collections.Generic;
using System.Text;

namespace DeletegateExample
{
    public class CarInfoEventArgs
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
            //触发事件之前要检查委托是否为null ?.
            NewCarInfo?.Invoke(this, new CarInfoEventArgs(car));
        }
    }

    /// <summary>
    /// Consumer类用作事件侦听器
    /// </summary>
    public class Consumer
    {
        private string _name;

        public Consumer(string name)
        {
            _name = name;
        }

        public void NewCarIsHere(object sender, CarInfoEventArgs e)
        {
            Console.WriteLine($"{_name}:car {e.Car} is new");
            ;
        }
    }
}
