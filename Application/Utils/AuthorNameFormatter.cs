using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;

namespace Application.Utils
{
    public static class AuthorNameFormatter
    {
        public static string FormatNames(string name)
        {
            string[] portuguesePrepositions = new string[]{"da", "de", "do", "das", "dos"};
            string[] parentage = new string[]{"FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA", "JUNIOR"};

            List<string> nameToFormat = name.Split(' ').ToList();

            int parentageIndex = 0, prepositionIndex = 0;
            string initialName = null, partialName = null;
            string surname = nameToFormat.Last();

            if(nameToFormat.Count > 1)
            {
                
                for(int i = 0; i < nameToFormat.Count; i++)
                {
                    partialName = null;

                    if(portuguesePrepositions.Contains(nameToFormat[i].ToLower()))
                    {
                        prepositionIndex = nameToFormat.IndexOf(nameToFormat[i]);
                        partialName = String.Format("{0} {1}",nameToFormat[prepositionIndex - 1], nameToFormat[i]);
                    }

                    if(!String.IsNullOrEmpty(partialName))
                    {
                        nameToFormat[prepositionIndex - 1] = partialName;
                        nameToFormat.RemoveAt(prepositionIndex);
                    }   
                }

                if(parentage.Contains(surname.ToUpper()))
                {
                    parentageIndex = nameToFormat.IndexOf(surname);
                    
                    if(parentageIndex > 1)
                    {
                        surname = string.Format("{0} {1}", nameToFormat[parentageIndex - 1], surname);
                        nameToFormat.RemoveAt(parentageIndex - 1);
                    }                       
                }
            }

            nameToFormat.RemoveAt(nameToFormat.Count - 1);

            if(nameToFormat.Count > 0)
            {
                nameToFormat = CapitalizeFirstLetter(nameToFormat);
                initialName = String.Join(" ", nameToFormat);
            }

            name = String.IsNullOrEmpty(initialName) ? surname.ToUpper() : String.Format("{0}, {1}", surname.ToUpper(), initialName);
        
            return name;
        }

        public static List<string> CapitalizeFirstLetter(List<string> names)
        {
            for(int i = 0; i < names.Count(); i++)
            {
                names[i] = names[i].First().ToString().ToUpper() + names[i].Substring(1).ToLower();
            }

            return names;
        }
    }
}