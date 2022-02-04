using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace ExemploRefit
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.WriteLine("Informe o seu CEP:");

                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando informações di CEP: " + cepInformado);

                var address = await cepClient.GetAddressAsync(cepInformado);

                Console.WriteLine($"\nLogradouro: {address.Logradouro}\nComplemento: {address.Complemento}" +
                    $"\nBairro: {address.Bairro} \nLocalidade: {address.Localidade} \nUF: {address.Uf}");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na consulta de cep: " + e.Message);
            }
        }
    }
}
