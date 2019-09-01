using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalamanCommanderWF
{
    public interface IElement
    {
        string FullPath { get; set; }
        string Name();
        string Copy(string destination);
      
        string Move(string destination);
       
        string Delete();
        string Rename(string newName);
        string Properties();
        //string ToPrintInWindow(int len);



    }
}
