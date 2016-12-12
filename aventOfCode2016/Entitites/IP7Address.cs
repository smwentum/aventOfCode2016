﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aventOfCode2016.Entitites
{
    public class IP7Address
    {

        public  List<string> hypernet { get; set; }
        public  List<string> outsideHypernet { get; set; }

        public IP7Address(string s)
        {
            s = s.Trim();
            bool inHypernet = false;
            string o="";
            string h="";
            outsideHypernet = new List<string>();
            hypernet = new List<string>();
            foreach (char c in s)
            {
                if (!char.IsLetter(c))
                {
                    inHypernet = !inHypernet;
                    if (o.Length > 0)
                    {
                        outsideHypernet.Add(o);
                        o = "";
                    }
                    else if (h.Length > 0)
                    {
                        hypernet.Add(h);
                        h = "";
                    }
                }
                else if (!inHypernet)
                {
                    o += c;
                }
                else
                {
                    h += c;
                }
            }
            if (o.Length > 0)
            {
                outsideHypernet.Add(o);
                o = "";
            }
            else if (h.Length > 0)
            {
                hypernet.Add(h);
                h = "";
            }

        }

        //public override string ToString()
        //{
        //    return string.Format("outside hypernet: {0} hypernet: {1}", outsideHypernet, hypernet);
        //}
        
        public  bool hasAutonomousBridgeBypassAnnotation(List<string> s)
        {
            bool ans = false;

            for (int j = 0; j < s.Count(); j++)
            {
                for (int i = 0; i < s[j].Length-3; i++)
                { 
                    if (s.ElementAt(j)[i] != s.ElementAt(j)[i + 1] && s.ElementAt(j)[i] == s.ElementAt(j)[i + 3] && s.ElementAt(j)[i + 1] == s.ElementAt(j)[i + 2])
                    {
                        ans = true;
                        break;
                    }
                }
            }

            return ans;
        }

        public bool isIP7()
        {
         
                if (hasAutonomousBridgeBypassAnnotation(hypernet))
                {
                    return false;
                }
            
            
                if (!hasAutonomousBridgeBypassAnnotation(outsideHypernet))
                {
                    return false; 
                }
            
            
            return true;
        }
    }
}
