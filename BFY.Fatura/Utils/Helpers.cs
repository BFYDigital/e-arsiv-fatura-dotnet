using NumberToWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Utils
{
    public class Helpers
    {
        public static string CurrencyToWordsTransformer(decimal amount, string language, string currency)
        {
            ITransformerFactory transformerFactory = new TransformerFactory();
            var transformer = transformerFactory.Create(language);
            var currencyToWords = transformer.ToCurrencyWords(amount, currency);

            return currencyToWords;
        }
    }
}
