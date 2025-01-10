using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string caminhoArquivo = "faturamento.json";

            string json = File.ReadAllText(caminhoArquivo);
            List<DadosFaturamento> faturamento = JsonConvert.DeserializeObject<List<DadosFaturamento>>(json);

            var diasComFaturamento = faturamento.Where(dia => dia.Valor > 0).ToList();

            double menorValor = diasComFaturamento.Min(dia => dia.Valor);
            double maiorValor = diasComFaturamento.Max(dia => dia.Valor);

            double mediaMensal = diasComFaturamento.Average(dia => dia.Valor);

            int diasAcimaMedia = diasComFaturamento.Count(dia => dia.Valor > mediaMensal);

            Console.WriteLine($"Menor valor de faturamento: {menorValor:C}");
            Console.WriteLine($"Maior valor de faturamento: {maiorValor:C}");
            Console.WriteLine($"Número de dias com faturamento acima da média mensal: {diasAcimaMedia}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: " + ex.Message);
        }
    }
}

class DadosFaturamento
{
    public int Dia { get; set; }
    public double Valor { get; set; }
}
