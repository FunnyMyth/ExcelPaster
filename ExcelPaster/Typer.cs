﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelPaster
{
    public class Typer
    {
        private Keyboard kb = new Keyboard();
        private int strokeDelay = 500;
      

        public void TypeCSVArray(List<List<String>> csv)
        {
            TypeCSVtoText(csv);
        }
        private bool StopCheck()
        {
           
            //Keyboard.IsKeyDown(Key.)
            return false;
        }
        private void SendKey(char c)
        {
            // SendKeys.Send(c.ToString());
            short b = Convert.ToSByte(c);
            // ((Keyboard.ScanCodeShort)b).ToString();
            Keyboard.VirtualKeyShort vKB = ((Keyboard.VirtualKeyShort)b);
            kb.SendVirtual(vKB);//Keyboard.ScanCodeShort.KEY_0);
           
            Thread.Sleep(strokeDelay);
        }
        private void NewCell()
        {
            //SendKeys.Send("{TAB}");
            kb.SendVirtual(Keyboard.VirtualKeyShort.TAB);
            Thread.Sleep(strokeDelay);
        }
        private void NewLine()
        {
            // SendKeys.Send("{ENTER}");
            kb.SendVirtual(Keyboard.VirtualKeyShort.RETURN);
            Thread.Sleep(strokeDelay);
        }
        private void TypeCSVtoText(List<List<String>> csv)
        {
            
            for (int i = 0;i <csv.Count();i++ )
            {
                List<string> line = csv[i];
                for (int j = 0; j < line.Count(); j++ )
                {
                    string cell = line[j];
                    for (int k = 0; k < cell.Count(); k++)
                    {
                        char c = cell[k];
                        SendKey(c);
                    }
                    if (j < line.Count())
                    {
                        NewCell();
                    }
                }
                if (i < csv.Count())
                {
                    NewLine();
                }
            }
        }
        private void TypeCSVtoPCCU(List<List<String>> csv)
        {

        }
    }
}
