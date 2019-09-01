using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GalamanCommanderWF
{
    internal class ActiveDirectory : DirectoryElement
    {
        public List<IElement> elements = new List<IElement>();
        public string Part { get; set; }

        public ActiveDirectory(string part) : base(part)
        {
            UpdateDirectory(part);
        }

        public string UpdateDirectory()
        {
            return UpdateDirectory(Part);
        }
        public string UpdateDirectory(string part)
        {
            try
            {
                elements.Clear();
                if (part == "")
                {
                    foreach (var drive in Directory.GetLogicalDrives())
                        elements.Add(new DirectoryElement(drive.ToString()));
                    Part = part;
                    return $"Logical drives ";
                }
                else
                {
                    foreach (var dir in Directory.GetDirectories(part))
                        elements.Add(new DirectoryElement(dir.ToString()));
                    foreach (var file in Directory.GetFiles(part))
                        elements.Add(new FileElement(file.ToString()));
                    Part = part;
                    return $"Active Directory: {part}";
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public void GoBack()
        {
            if (Part.Length < 4) Part = "";
            if (Part != "")
               Part = Directory.GetParent(Part).ToString();               
           
            UpdateDirectory();
        }

        public string CreateNewDirectory(string name)
        {
            try
            {
                if (!Directory.Exists(FullPath + "\\" + name))
                {
                    Directory.CreateDirectory(FullPath + "\\" + name);
                    return $"Directory {FullPath + "\\" + name} created ";
                }
                else return $"Directory {FullPath + "\\" + name} Exist!!! ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




    }
}
