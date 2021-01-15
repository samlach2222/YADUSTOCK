using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /// <summary>
    /// Storage layer, use JSON format; saves into a file
    /// </summary>
    public class JsonStorage : IStorage
    {
        private string file;

        public JsonStorage(string filename)
        {
            //Sauvegarde dans l'emplacement AppData\Roaming\YaDuStock\ de l'utilisateur
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            filePath += "\\Yadustock";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            filePath += "\\" + filename;
            this.file = filePath;
        }

        public void Save(Memory m)
        {
            //throw new NotImplementedException();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Memory));

            using (Stream stream = new FileStream(file, FileMode.Create))
            {
                ser.WriteObject(stream, m);
            }
        }

        Memory IStorage.Load()
        {
            //throw new NotImplementedException();
            Memory m = null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Memory));
                using (Stream stream = new FileStream(file, FileMode.Open))
                {
                    m = ser.ReadObject(stream) as Memory;
                }
            }
            catch
            {
                m = new Memory();
            }

            return m;
        }
    }
}
