using EPCTagReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EPCTagReader.HelperMethods
{
    public static class Reader
    {
        public static IEnumerable<CSVRecord> ReadCSV(string path)
        {
            var csvData = new List<CSVRecord>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        var line = reader.ReadLine();
                        var record = line.Split(';');

                        var company = new Company
                        {
                            Prefix = record[0],
                            Name = record[1]
                        };

                        var item = new Item
                        {
                            Name = record[2],
                            Reference = record[3]
                        };

                        var csvRecord = new CSVRecord
                        {
                            Company = company,
                            Item = item
                        };

                        csvData.Add(csvRecord);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                    }
                    
                }
            }
            return csvData;
        }

        public static IEnumerable<string> ReadTags(string path)
        {
            IEnumerable<string> tagsString = null;

            try
            {
                tagsString = File.ReadLines(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to exit program.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            return tagsString;
        }
    }
}
