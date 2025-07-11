// csharp/ShippingService.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce
{
    public class ShippingService
    {
        private const double ShippingRatePerKg = 30.0;

        public static void Ship(List<IShippable> shippableItems)
        {
            if (!shippableItems.Any())
            {
                return;
            }

            Console.WriteLine("** Shipment notice **");
            double totalWeight = 0.0;

            foreach (var item in shippableItems)
            {
                Console.WriteLine($"1x {item.Name} {(int)(item.Weight * 1000)}g");
                totalWeight += item.Weight;
            }

            Console.WriteLine($"Total package weight {totalWeight}kg");
        }

        public static double CalculateShippingFee(List<IShippable> shippableItems)
        {
            if (!shippableItems.Any())
            {
                return 0.0;
            }

            double totalWeight = shippableItems.Sum(item => item.Weight);
            return totalWeight * ShippingRatePerKg;
        }
    }
}
