using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServicioApi.DataObjects.Utils
{
    public partial class UtilsLib
    {
        public byte[] CompressDataTable(DataTable dataTable)
        {
            if (dataTable == null)
                throw new ArgumentNullException(nameof(dataTable));

            // Asegurar que el DataTable tenga un nombre
            if (string.IsNullOrEmpty(dataTable.TableName))
                dataTable.TableName = "DefaultTableName";
            // Serializar DataTable a XML
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataTable));
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, dataTable);
                byte[] xmlData = xmlStream.ToArray();

                // Comprimir XML
                using (MemoryStream compressedStream = new MemoryStream())
                {
                    using (GZipStream gzipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                    {
                        gzipStream.Write(xmlData, 0, xmlData.Length);
                    }
                    return compressedStream.ToArray();
                }
            }
        }
    }
}
