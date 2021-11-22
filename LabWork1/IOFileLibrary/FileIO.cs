using System;
using System.IO;

namespace IOFileLibrary
{
    public class FileIO
    {
        public readonly string path;


        public FileIO(string absolutePath)
        {
            path = absolutePath;
        }



        public void DeleteAllData()
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ReadAllFile()
        {
            string dataOfFile = null;

            try
            {
                FileInfo fileInfo = new FileInfo(path);
                if (!fileInfo.Exists)
                {
                    fileInfo.Create();
                }

                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
                {
                    dataOfFile = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dataOfFile;
        }

        public bool AddData(string updateData)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                if (!fileInfo.Exists)
                {
                    fileInfo.Create();
                }

                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                {
                    sw.Write(updateData);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;

        }


    }
}
