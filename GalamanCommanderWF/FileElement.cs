using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GalamanCommanderWF
{
    class FileElement : IElement
    {
        public string FullPath { get; set; }
        public string Name()
        {
            FileInfo info = new FileInfo(FullPath);
            return info.Name;
        }

        public FileElement(string part)
        {
            FullPath = part;
        }
        public string Copy(string destination)
        {
            try
            {
                File.Copy(FullPath, destination + "\\" + Name());
                return $"Copy OK ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Move(string destination)
        {
            try
            {
                if (File.Exists(FullPath))
                {
                    File.Move(FullPath, destination + "\\" + Name());
                    return $"Move OK ";
                }
                else return $"File {FullPath} not exists!!! ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete()
        {
            try
            {
                if (File.Exists(FullPath))
                {
                    File.Delete(FullPath);
                    return $"File {FullPath} deleted OK ";
                }
                else return $"File {FullPath} not exists!!! ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Rename(string newName)
        {
            try
            {
                if (File.Exists(FullPath))
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(FullPath, newName);
                    return "Rename OK ";
                }
                else return $"File {FullPath} not exists!!! ";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public override string ToString()
        {
            string str = Name();
            while (str.Length < 40)
                str += " ";
            str += "<file> create ";
            str += File.GetCreationTime(FullPath).ToShortDateString();
            while (str.Length < 65)
                str += " ";
            str += "last access ";
            str += File.GetLastAccessTime(FullPath);
            return str;
        }
        public string Properties()
        {
            string str = "";
            FileInfo fileInfo = new FileInfo(FullPath);
            str = File.GetAttributes(FullPath).ToString();
            str += ", " + fileInfo.Length.ToString() + " bytes";

            return str;
        }
  
        //************   Static Medhods  *****************//

        public static string Copy(string sourse, string destination)
        {
            try
            {
                if (File.Exists(sourse))
                {
                    File.Copy(sourse, destination);
                    return $"Copy OK ";
                }
                else return $"File {sourse} not exists!!! ";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string Move(string sourse, string destination)
        {
            try
            {
                if (File.Exists(sourse))
                {
                    File.Move(sourse, destination);
                    return $"Move OK ";
                }
                else return $"File {sourse} not exists!!! ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string Delete(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return $"File {path} deleted OK ";
                }
                else return $"File {path} not exists!!! ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string Rename(string path, string newName)
        {
            try
            {
                if (File.Exists(path))
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(path, newName);
                    return "Rename OK ";
                }
                else return $"File {path} not exists!!! ";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static string Read(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    return File.ReadAllText(path, Encoding.Default);
                }
                else return $"File {path} not Exist!!! ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
