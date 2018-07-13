﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelPaster
{
    public class CSVReader
    {
        private List<List<String>> ArrayStorage = new List<List<string>>();
        private List<String> CurLineList; 
        private String CurCell = "";

        public List<List<String>> GetArrayStorage()
        {
            return ArrayStorage;
        }
        public void ParseCSV(string csv)
        {
            using (var fs = new FileStream(csv, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var sr = new StreamReader(fs);
               ParseCSV(sr);
            }
        }
        private void ReadCharacter(char c)
        {
            if (c != ',')
            {
                CurCell += c;
            }
            else//save cell and wipe it clean for next
            {
                CurLineList.Add(CurCell);
                CurCell = "";
            }
        }
        private void ParseCSV(StreamReader stream)
        {
            string curline = "";
            while (curline != null)
            {
                curline = stream.ReadLine();
                if (curline != null)//end of file?
                {
                    CurLineList = new List<string>();
                    foreach (char c in curline)
                    {
                        ReadCharacter(c);
                    }
                    ArrayStorage.Add(CurLineList);
                }
                else
                {
                    break;
                }
            }
           

            
        }
    }
}
