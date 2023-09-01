using System;
using System.Collections.Generic;
using System.Linq;

namespace Определение_просрочки
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();

            warehouse.Work();
        }
    }

    class Conserva
    {
        public Conserva(string name, int yearOfProduction, int expirationDate) 
        {
            Name = name;
            YearOfProduction = yearOfProduction;
            ExpirationDate = expirationDate;
        }

        public string Name { get; private set; }
        public int YearOfProduction { get; private set; }
        public int ExpirationDate { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Название: {Name}, Год изготовления: {YearOfProduction}," +
                              $" Годен до: {ExpirationDate}");
        }
    }

    class Warehouse
    {
        private List<Conserva> _conservas = new List<Conserva>();

        private int _currentDate;

        public Warehouse()
        {
            _conservas = Create();
            _currentDate = DateTime.Now.Year;
        }

        public void Work()
        {
            ShowAllConservas();
            Console.WriteLine();
            SortConservas();
        }

        private List<Conserva> Create()
        {
            List<Conserva> conservas = new List<Conserva>() 
            { 
                new Conserva("Тушеная говядина", 2015, 2019),
                new Conserva("Перловка", 2019, 2024),
                new Conserva("Горошек зеленый", 2016, 2020),
                new Conserva("Кукуруза", 2017, 2023),
                new Conserva("Маринованные огурцы", 2020, 2024),
                new Conserva("Кукуруза", 2014, 2018),
                new Conserva("Тушеная говядина", 2019, 2022),
                new Conserva("Перловка", 2019, 2024),
                new Conserva("Горошек зеленый", 2017, 2022),
            };

            return conservas;
        }

        private void SortConservas()
        {
            var sortredListConservas = _conservas.Where(conserva => conserva.ExpirationDate < _currentDate);

            Console.WriteLine("Просроченные Консервы\n");

            foreach (Conserva conserva in sortredListConservas)
            {
                conserva.ShowInfo();
            }
        }

        private void ShowAllConservas()
        {
            Console.WriteLine("Весь список консерв");

            foreach (Conserva conserva in _conservas)
            {
                conserva.ShowInfo();
            }
        }
    }
}
