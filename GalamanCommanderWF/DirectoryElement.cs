using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GalamanCommanderWF
{
    public class DirectoryElement : IElement

    {
        public string FullPath { get; set; }
        public string Name()
        {
            DirectoryInfo info = new DirectoryInfo(FullPath);
            return info.Name;
        }

        public DirectoryElement(string path)
        {
            FullPath = path;
        }
        public string Copy(string destination)
        {
            try
            {
                if (Directory.Exists(FullPath))
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(FullPath, destination + "\\" + Name());
                    return $"Copy OK ";
                }
                else return $"Directory{FullPath} not Exist!!! ";
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
                if (Directory.Exists(FullPath))
                {
                    Directory.Move(FullPath, destination + "\\" + Name());
                    return $"Move OK ";
                }
                else return $"Directory{FullPath} not Exist!!! ";
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
                if (Directory.Exists(FullPath))
                {
                    Directory.Delete(FullPath, true);
                    return $"Directory {FullPath} deleted !!!";
                }
                else return $"Directory {FullPath} not Exist!!! ";
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
                if (Directory.Exists(FullPath))
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.RenameDirectory(FullPath, newName);
                    return $"renamed OK ";
                }
                else return $"Directory {FullPath} not Exist!!! ";
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
            str += "<DIR> create ";
            str += Directory.GetCreationTime(FullPath).ToShortDateString();
            while (str.Length < 65)
                str += " ";
            str += "last access ";
            str += Directory.GetLastAccessTime(FullPath);
            return str;
        }
        public string Properties()
        {
            string str = "";
            DirectoryInfo dir = new DirectoryInfo(FullPath);
            str = dir.Attributes.ToString();

            return str;
        }
     



        //************************* Static Methods ************************//
        public static string Copy(string sourse, string destination)
        {
            try
            {
                if (Directory.Exists(sourse))
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(sourse, destination);
                    return $"Copy OK ";
                }
                else return $"Directory{sourse} not Exist!!! ";
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
                if (Directory.Exists(sourse))
                {
                    Directory.Move(sourse, destination);
                    return $"Move OK ";
                }
                else return $"Directory{sourse} not Exist!!! ";
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
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    return $"Directory {path} deleted !!!";
                }
                else return $"Directory {path} not Exist!!! ";
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
                if (Directory.Exists(path))
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.RenameDirectory(path, newName);
                    return $"renamed OK ";
                }
                else return $"Directory {path} not Exist!!! ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Dir(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    string str = "";
                    List<IElement> elements = new List<IElement>();
                    foreach (string i in Directory.GetDirectories(path))
                        elements.Add(new DirectoryElement(i));
                    foreach (string i in Directory.GetFiles(path))
                        elements.Add(new FileElement(i));
                    foreach (var i in elements)
                        str += i.ToString() + "\n";

                    return str;
                }
                else return $"Directory {path} not Exist!!! ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static bool ExistsElement(string path)
        {
            return Directory.Exists(path) || File.Exists(path);
        }





    }
}
