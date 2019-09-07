using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

namespace gdp_agg
{
   public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            aggGDP();
        }
        public static void aggGDP()
        {

            string[] lines = File.ReadAllLines(@"..\..\..\..\data_datafile.csv");
            Hashtable ht = new Hashtable();
            ht.Add("South Africa", "Africa");
            ht.Add("India", "Asia");
            ht.Add("China", "Asia");
            ht.Add("Japan", "Asia");
            ht.Add("Indonesia", "Asia");
            ht.Add("Russia", "Asia");
            ht.Add("Saudi Arabia", "Asia");
            ht.Add("Turkey", "Asia");
            ht.Add("Argentina", "South America");
            ht.Add("Brazil", "South America");
            ht.Add("Australia", "Oceania");
            ht.Add("Canada", "North America");
            ht.Add("Mexico", "North America");
            ht.Add("USA", "North America");
            ht.Add("France", "Europe");
            ht.Add("Germany", "Europe");
            ht.Add("Italy", "Europe");
            ht.Add("United Kingdom", "Europe");
            ht.Add("Republic of Korea", "Asia");
            Dictionary<string, double> population = new Dictionary<string, double>();

            Dictionary<string, double> gdp2012 = new Dictionary<string, double>();
            gdp2012.Add("South America", 0.0);
            gdp2012.Add("Oceania", 0.0);
            gdp2012.Add("North America", 0.0);
            gdp2012.Add("Asia", 0.0);
            gdp2012.Add("Europe", 0.0);
            gdp2012.Add("Africa", 0.0);
            population.Add("South America", 0.0);
            population.Add("Oceania", 0.0);
            population.Add("North America", 0.0);
            population.Add("Asia", 0.0);
            population.Add("Europe", 0.0);
            population.Add("Africa", 0.0);
            foreach (string line in lines)
            {
                string[] data = line.Split(",");
                string country = data[0].Replace("\"", "");
                string Populations = data[4].Replace("\"", "");
                string gdpCountry = data[7].Replace("\"", "");
                if (ht.ContainsKey(country))
                {
                    string continent = (string)ht[country];
                    if (population.ContainsKey(continent))
                    {
                        double sumPopulation = (double)population[continent] + double.Parse(Populations);
                        population[continent] = sumPopulation;
                        double sumGDP = (double)gdp2012[continent] + double.Parse(gdpCountry);
                        gdp2012[continent] = sumGDP;
                    }

                   ;
                }

            }
            Dictionary<String, Details> eList = new Dictionary<String, Details>();
            ICollection key = gdp2012.Keys;
            foreach (string k in key)
            {
                Details ag = new Details();

                ag.GDP_2012 = (double)gdp2012[k];
                ag.POPULATION_2012 = (double)population[k];
                eList.Add(k, ag);

            }


            string result = JsonConvert.SerializeObject(eList, Formatting.Indented);
            string path = @"../../../../dataOutput.json";
            using (var tw = new StreamWriter(path, true))
            {
                tw.Write(result.ToString());
                tw.Close();
            }

            /*File.WriteAllText(path, JsonConvert.SerializeObject(result));*/
            /*Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();*/
        }

    }

    class Details
    {
        public double GDP_2012;
        public double POPULATION_2012;
    }

}
 

   
