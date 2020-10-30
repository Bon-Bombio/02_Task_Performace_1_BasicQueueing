using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queuing
{
    
    public class CashierClass
    {   
    private int x = 10000;
    public static string getNumberInQueue = "";
    public static Queue<string> CashierQueue = new Queue<string>();  

    public string CashierGenerateNumber(string CashierNumber)
    {
        x++;
        CashierNumber = CashierNumber + x.ToString();
        return CashierNumber;
        }
    }  
}
