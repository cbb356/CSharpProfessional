using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class MyDictionary
    {
        private Dictionary<string, Translation> _dictionary = new Dictionary<string, Translation>();

        public void Add(string ukr, string russian, string english)
        { 
            _dictionary.Add(ukr.Trim().ToLower(), new Translation(russian.Trim().ToLower(), english.Trim().ToLower()));
        }

        public string? GetTranslation (string ukrainian, TranlationLanguage language)
        {
            if (string.IsNullOrWhiteSpace(ukrainian))
                return null;

            if (_dictionary.TryGetValue(ukrainian.Trim().ToLower(), out Translation? pair))
            {
                return language == TranlationLanguage.Russian ? pair.Russian : pair.English;
            }

            return null;
        }

        public void PrintEntry(string word)
        {
            try
            {
                Console.WriteLine($"{word} - {_dictionary[word.ToLower()]}");
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
