using EPCTagReader.HelperMethods;
using EPCTagReader.Models;
using SGTINDecoder;
using SGTINDecoder.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPCTagReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var HEX_SGTIN_96_Tags = Reader.ReadTags($"{AppDomain.CurrentDomain.BaseDirectory}/Data/tags.txt");

            const long MilkaOreoReference = 1253252;
            List<SGTIN_96> decodedTags = new List<SGTIN_96>();

            foreach(var tag in HEX_SGTIN_96_Tags)
            {
                var result = Decoder.Decode_SGTIN_96(tag);
                decodedTags.Add(result);
            }

            var milkaOreoTags = decodedTags.Where(x => x.ItemReference == MilkaOreoReference);
            var notProperlyEncodedTags = decodedTags.Where(x => !x.IsProperlyEncoded);

            Console.WriteLine($"Milka Oreo count: {milkaOreoTags.Count()}");
            Console.WriteLine($"Not properly encoded: {notProperlyEncodedTags.Count()}");
            Console.WriteLine($"-----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"List of Milka Oreo tags:");
            foreach (var tag in milkaOreoTags)
            {
                Console.WriteLine($"Serial number: {tag.SerialNumber}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"List of not properly encoded tags:");
            foreach (var tag in notProperlyEncodedTags)
            {
                Console.WriteLine(tag.HexValue);
            }
            Console.ReadKey();
        }
    }
}
