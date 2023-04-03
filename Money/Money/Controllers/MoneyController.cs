using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Money.Controllers
{
    public class MoneyController : Controller
    {
        // Action afficher la vue Money
        public ActionResult Money()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Money(FormCollection collection)
        {

            string fromCurrency = collection["fromCurrency"];
            string toCurrency = collection["toCurrency"];
            string amountString = collection["amount"];

            Regex regex = new Regex(@"^\d+(\.\d{1,2})?$");

            if (!string.IsNullOrEmpty(amountString) && regex.IsMatch(amountString))
            {
                decimal amount = decimal.Parse(amountString);
                decimal result = Convert(fromCurrency, toCurrency, amount);
                ViewBag.Result = result;
            }
            else
            {
                ViewBag.Result = "Invalid input, please enter a valid number";
            }
            return View();
        }

    private decimal Convert(string fromCurrency, string toCurrency, decimal amount)
    {
        // Définissez les taux de change fixes utilisés pour la conversion
        var exchangeRates = new Dictionary<string, decimal>
        {
            { "EUR", 1.0m },
            { "USD", 1.25m },
            { "GBP", 0.9m }
        };

        decimal fromRate = exchangeRates[fromCurrency];
        decimal toRate = exchangeRates[toCurrency];

        return (amount / fromRate) * toRate;
    }
    }
}