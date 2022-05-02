using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bill bill1 = new Bill();
            bill1.Items = new List<Item>();
            Item item1 = new Exceptionalitem("book", false, 12.49m);
            Item item2 = new NonExceptionalitem("music CD", false, 14.99m);
            Item item3 = new Exceptionalitem("Chololate bar", false, 0.85m);
            bill1.Items.Add(item1);
            bill1.Items.Add(item2);
            bill1.Items.Add(item3);


            Bill bill2 = new Bill();
            bill2.Items = new List<Item>();
            Item item4 = new Exceptionalitem("Chocolate", true, 10.00m);
            Item item5 = new NonExceptionalitem("Perfume", true, 47.50m);
            bill2.Items.Add(item4);
            bill2.Items.Add(item5);

            Bill bill3 = new Bill();
            bill3.Items = new List<Item>();
            Item item6 = new NonExceptionalitem("Perfume", true, 27.99m);
            Item item7 = new NonExceptionalitem("Perfume", false, 18.99m);
            Item item8 = new Exceptionalitem("Head Ache Pills", false, 9.75m);
            Item item9 = new Exceptionalitem("Chocolate", true, 11.25m);
            bill3.Items.Add(item6);
            bill3.Items.Add(item7);
            bill3.Items.Add(item8);
            bill3.Items.Add(item9);

            List<Bill> bills = new List<Bill>();
            bills.Add(bill1);
            bills.Add(bill2);
            bills.Add(bill3);


            foreach (var bill in bills)
            {
                if (bill != null && bill.Items.Count > 0)
                {
                    foreach (var item in bill.Items)
                    {
                        Console.WriteLine("Name: {0} Price :{1} Imported : {2} Tax: {3}", item.Name, Math.Round((Math.Ceiling(item.GetTotalPrice() * 2000)) / 2000, 2, MidpointRounding.ToPositiveInfinity), item.IsImported, item.GetTax());
                        bill.TaxAmount = bill.TaxAmount + item.GetTax();
                        bill.TotalBill = bill.TotalBill + item.GetTotalPrice();
                    }

                    Console.WriteLine("Sales Taxes : {0} Total :{1} ", Math.Round(bill.TaxAmount, 2), Math.Round(bill.TotalBill, 2), 2);
                }
            }
            Console.ReadLine();
        }
    }

    public class Bill
    {
        public List<Item> Items { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalBill { get; set; }
    }

    public abstract class Item
    {
        public string Name { get; set; }

        public decimal OriginalPrice { get; set; }

        public bool IsImported { get; set; }

        public abstract decimal GetTax();

        public decimal GetTotalPrice()
        {
            return this.OriginalPrice + this.GetTax();
        }
    }

    public class Exceptionalitem : Item
    {
        public Exceptionalitem(string name, bool isImported, decimal originalPrice)
        {
            this.Name = name;
            this.IsImported = isImported;
            this.OriginalPrice = originalPrice;
        }
        public override decimal GetTax()
        {
            {
                if (IsImported)
                {
                    return Math.Round((Math.Ceiling(OriginalPrice * (5m / 100m) * 20)) / 20, 2, MidpointRounding.ToPositiveInfinity);
                }

                return 0m;
            }
        }
    }

    public class NonExceptionalitem : Item
    {
        public NonExceptionalitem(string name, bool isImported, decimal originalPrice)
        {
            this.Name = name;
            this.IsImported = isImported;
            this.OriginalPrice = originalPrice;
        }

        public override decimal GetTax()
        {
            {
                if (IsImported)
                {
                    return Math.Round((Math.Ceiling(OriginalPrice * (15m / 100m) * 20)) / 20, 2, MidpointRounding.ToPositiveInfinity);
                }

                return Math.Round((Math.Ceiling(OriginalPrice * (10m / 100m) * 20)) / 20, 2, MidpointRounding.ToPositiveInfinity);
            }
        }
    }
}
