using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared_Static_Class.Helpers;

public static class DateHelpers
{
    // Método que calcula a diferença de tempo entre duas datas (em dias úteis, horas, minutos, e segundos)
    public static TimeSpan CalcularDiferencaDeTempo(DateTime startDate, DateTime endDate)
    {
        // Verificar se a data inicial não é posterior à data final
        if (startDate > endDate)
        {
            throw new ArgumentException("A data inicial não pode ser posterior à data final.");
        }

        // Lista de feriados do ano da data inicial
        var feriados = ObterFeriados(startDate.Year);

        // Ajustar a data inicial para o próximo dia útil, caso seja fim de semana ou feriado
        while (startDate.DayOfWeek == DayOfWeek.Saturday ||
               startDate.DayOfWeek == DayOfWeek.Sunday ||
               feriados.Contains(startDate.Date))
        {
            startDate = startDate.AddDays(1).Date; // Avança para o início do próximo dia
        }

        // Caso a data final esteja em um fim de semana ou feriado, ajustar para o último dia útil anterior
        while (endDate.DayOfWeek == DayOfWeek.Saturday ||
               endDate.DayOfWeek == DayOfWeek.Sunday ||
               feriados.Contains(endDate.Date))
        {
            endDate = endDate.AddDays(-1).Date.AddHours(23).AddMinutes(59).AddSeconds(59); // Retrocede ao último instante do último dia útil
        }

        // Inicializar o total de tempo válido
        TimeSpan totalTempoValido = TimeSpan.Zero;

        // Calcular o tempo apenas nos dias úteis
        while (startDate < endDate)
        {
            if (startDate.DayOfWeek != DayOfWeek.Saturday &&
                startDate.DayOfWeek != DayOfWeek.Sunday &&
                !feriados.Contains(startDate.Date))
            {
                // Determinar o tempo útil restante no dia atual
                DateTime inicioDoDia = startDate.Date;
                DateTime fimDoDia = startDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                // Calcular a janela válida do dia atual
                DateTime inicioValido = startDate > inicioDoDia ? startDate : inicioDoDia;
                DateTime fimValido = endDate < fimDoDia ? endDate : fimDoDia;

                // Somar o tempo válido
                if (inicioValido < fimValido)
                {
                    totalTempoValido += fimValido - inicioValido;
                }
            }

            // Avançar para o próximo dia
            startDate = startDate.AddDays(1).Date;
        }

        return totalTempoValido;
    }


    public static int CalculeDiasUteis(DateTime startDate, DateTime endDate)
    {
        int days = 0;

        // Obter todos os feriados do ano corrente
        var feriados = ObterFeriados(startDate.Year);

        // Garantir que a data final não seja ignorada
        endDate = endDate.AddDays(1); // Adiciona um dia para considerar o final do intervalo

        // Loop que percorre cada dia no intervalo
        while (startDate < endDate)
        {
            // Verificar se é um dia útil (não é fim de semana nem feriado)
            if (startDate.DayOfWeek != DayOfWeek.Saturday
                && startDate.DayOfWeek != DayOfWeek.Sunday
                && !feriados.Contains(startDate.Date))
            {
                days++;
            }

            // Avançar para o próximo dia
            startDate = startDate.AddDays(1);
        }

        return days;
    }

    // Método para obter os feriados de um ano específico
    private static List<DateTime> ObterFeriados(int ano)
    {
        // Feriados fixos
        List<DateTime> feriados = new List<DateTime>
        {
            new DateTime(ano, 1, 1),  // Ano Novo
            new DateTime(ano, 4, 21), // Tiradentes
            new DateTime(ano, 5, 1),  // Dia do Trabalhador
            new DateTime(ano, 9, 7),  // Independência do Brasil
            new DateTime(ano, 10, 12), // Nossa Senhora Aparecida
            new DateTime(ano, 11, 2),  // Finados
            new DateTime(ano, 11, 15), // Proclamação da República
            new DateTime(ano, 12, 25), // Natal

            // Feriados locais Recife
            new DateTime(ano, 6, 24),  // São João
            new DateTime(ano, 7, 16),  // Nossa Senhora do Carmo
            new DateTime(ano, 12, 8),  // Nossa Senhora da Conceição

            // Feriados móveis
            CalcularCarnaval(ano),
            CalcularSextaFeiraSanta(ano),
            CalcularCorpusChristi(ano)
        };

        return feriados;
    }

    private static DateTime CalcularCarnaval(int ano)
    {
        DateTime pascoa = CalcularPascoa(ano);
        return pascoa.AddDays(-47); // Carnaval é 47 dias antes da Páscoa
    }

    // Função para calcular a Sexta-feira Santa (2 dias antes da Páscoa)
    private static DateTime CalcularSextaFeiraSanta(int ano)
    {
        DateTime pascoa = CalcularPascoa(ano);
        return pascoa.AddDays(-2);
    }

    // Função para calcular o Corpus Christi (60 dias após a Páscoa)
    private static DateTime CalcularCorpusChristi(int ano)
    {
        DateTime pascoa = CalcularPascoa(ano);
        return pascoa.AddDays(60);
    }

    private static DateTime CalcularPascoa(int ano)
    {
        int a = ano % 19;
        int b = ano / 100;
        int c = ano % 100;
        int d = b / 4;
        int e = b % 4;
        int f = (b + 8) / 25;
        int g = (b - f + 1) / 3;
        int h = (19 * a + b - d - g + 15) % 30;
        int i = c / 4;
        int k = c % 4;
        int l = (32 + 2 * e + 2 * i - h - k) % 7;
        int m = (a + 11 * h + 22 * l) / 451;
        int mes = (h + l - 7 * m + 114) / 31;
        int dia = ((h + l - 7 * m + 114) % 31) + 1;

        return new DateTime(ano, mes, dia);
    } 
}
