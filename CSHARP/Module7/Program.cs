using System;
using System.Collections.Generic;

namespace Module7
{
    /// <summary>
    /// Идентифицируемы объект
    /// </summary>
    abstract class IdentifiedObject
    {
        private static string name;
        public static string Name
        {
            get => name;
            set
            {
                if (value.Length > 0)
                    name = value;
                else throw new Exception("Задано пустое имя");
            }
        }
        public static void ShowName()
        {
            Console.WriteLine(name);
        }
    }
    /// <summary>
    /// Доставка
    /// </summary>
    class Delivery : IdentifiedObject
    {
        private string address;
        internal virtual string Address { get; set; }
        public Delivery()
        {
            address = "Земля";
        }
        public Delivery(string address) => this.address = address;
    }
    /// <summary>
    /// Единица, выполняющая курьерские функции
    /// </summary>
    abstract class CourierUnit : IdentifiedObject
    {
        protected abstract uint PermissibleWeight { get; set; }
    }
    /// <summary>
    /// Человек
    /// </summary>
    class Person : IdentifiedObject
    {
        private byte weight;
        private byte height;
        protected byte Weight
        {
            private protected get => weight;
            set
            {
                if (value > 0)
                    weight = value;
            }
        }
        protected byte Height
        {
            get => height;
            set
            {
                if (value > 0)
                    height = value;
            }
        }
        public uint GetPower()
        {
            return (uint)(weight * height / 1000);
        }
    }
    /// <summary>
    /// Курьер
    /// </summary>
    class Courier<TPerson> : CourierUnit where TPerson : Person
    {
        private uint permissibleWeight;
        internal TPerson person;
        protected override uint PermissibleWeight
        {
            get => permissibleWeight;
            set
            {
                if (value > 0 && value < person.GetPower())
                    permissibleWeight = value;
                else throw new Exception("Допустимый вес должен быть больше 0 и меньше 15");
            }
        }
    }
    /// <summary>
    /// Курьерская служба
    /// </summary>
    class CourierCompany : CourierUnit
    {
        private uint permissibleWeight;
        protected override uint PermissibleWeight
        {
            get => permissibleWeight;
            set
            {
                if (value > 0)
                    permissibleWeight = value;
                else throw new Exception("Допустимый вес должен быть больше 0");
            }
        }
    }
    /// <summary>
    /// Доставка на дом
    /// </summary>
    /// <typeparam name="TCourierUnit">доставщик</typeparam>
    class HomeDelivery<TCourierUnit> : Delivery where TCourierUnit : CourierUnit
    {
        public uint distance;
        public CourierUnit courierUnit;
        public HomeDelivery(uint distance, TCourierUnit courierUnit)
        {
            this.distance = distance;
            this.courierUnit = courierUnit;
        }
    }
    /// <summary>
    /// Расстояние от склада до пункта доставки
    /// </summary>
    struct DistanceToPickPoint
    {
        internal double distance;
        public static DistanceToPickPoint operator +(DistanceToPickPoint distance1, DistanceToPickPoint distance2)
        {
            DistanceToPickPoint newDistance = new DistanceToPickPoint();
            newDistance.distance = distance1.distance + distance2.distance;
            return newDistance;
        }
    }
    /// <summary>
    /// Доставка в пункт выдачи
    /// </summary>
    class PickPointDelivery : Delivery
    {
        public double summaryDistance;
        public PickPointDelivery(string newAddress, double dist)
        {
            base.Address = newAddress;
            summaryDistance = dist;
        }
        public PickPointDelivery(double dist) => summaryDistance = dist;
        public PickPointDelivery(double dist1, double dist2) => summaryDistance = dist1 + dist2;
    }
    /// <summary>
    /// Строка
    /// </summary>
    static class StringExtension
    {
        public static bool ContainsSpace(this string str)
        {
            return str.Contains(" ") ? true : false;
        }
    }
    /// <summary>
    /// Доставка в розничный магазин
    /// </summary>
    class ShopDelivery : Delivery
    {
        private string address;
        internal override string Address
        {
            get => address;
            set
            {
                if (value.ContainsSpace())
                    address = value;
            }
        }
    }
    /// <summary>
    /// Товар
    /// </summary>
    class Product : IdentifiedObject
    {
        private uint weight;
        private uint volume;
        public uint Weight
        {
            get => weight;
            set
            {
                if (value > 0)
                    weight = value;
            }
        }
        public uint Volume
        {
            get => volume;
            set
            {
                if (value > 0)
                    volume = value;
            }
        }
        public Product(uint weight, uint volume)
        {
            this.weight = weight;
            this.volume = volume;
        }
    }
    /// <summary>
    /// Номер заказа
    /// </summary>
    /// <typeparam name="T">тип номера</typeparam>
    class Number<T>
    {
        public T num;
    }
    /// <summary>
    /// Заказ
    /// </summary>
    /// <typeparam name="TDelivery">доставка</typeparam>
    /// <typeparam name="TNumber">номер</typeparam>
    class Order<TDelivery, TNumber> where TDelivery : Delivery where TNumber : Number<int>
    {
        public TDelivery Delivery;
        public List<Product> products;
        public int number;
        public Order(TNumber number)
        {
            products = new List<Product>();
            this.number = number.num;
        }
        public Product this[int index]
        {
            get
            {
                return products[index];
            }
            set
            {
                products[index] = value;
            }
        }
        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
    }
    class Program
    {
        static void Main() => Console.ReadKey();
    }
}
