using DataAccess;
using EntityModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProcessFileCsvBLL
    {
        private string FormatFile;


        public ProcessFileCsvBLL(string piFormatFile)
        {
            this.FormatFile = piFormatFile;
        }

        /// <summary>
        /// Read file send Web api
        /// </summary>
        /// <param name="piFile">Stream file</param>
        public void ReaderFile(Stream piFile, bool ValidateFormatColumn = false)
        {
            List<Product> piLstProduct = new List<Product>();
            using (var reader = new StreamReader(piFile))
            {
                int vlPrimeraLineaCol = 0;
                if (ValidateFormatColumn)
                {
                    ValidateFormatFile(reader.ReadLine());
                }

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    List<string> values = line.Split(',').ToList();
                    if (vlPrimeraLineaCol > 0)
                    {
                        Processor(values, piLstProduct);
                    }
                    vlPrimeraLineaCol++;
                }

                if (piLstProduct.Count > 0)
                {
                    Writer(piLstProduct);
                }


            }

        }

        private void ValidateFormatFile(string piLine)
        {
            try
            {
                if (string.IsNullOrEmpty(piLine))
                    throw new Exception("Las columnas del archivo deben contener un nombre");

                if (!string.Equals(piLine, this.FormatFile))
                {
                    throw new Exception("El nombre de las columnas no es correcto");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void Processor(List<string> piValues, List<Product> piLstProduct)
        {
            Product vlProduct;

            if (!piValues.Any(i => i == string.Empty))
            {
                vlProduct = new Product();
                vlProduct.Name = piValues[0];

                Brand VLBrand = new Brand();
                VLBrand.Name = piValues[1];
                vlProduct.Brand = VLBrand;

                vlProduct.Price = Convert.ToDecimal(piValues[2]);
                vlProduct.NumberStock = Convert.ToInt16(piValues[3]);
                vlProduct.State = piValues[4];
                vlProduct.DiscountRate = Convert.ToDecimal(piValues[5]);

                piLstProduct.Add(vlProduct);
            }

        }
        private void Writer(List<Product> piLstProduct)
        {
            ProductDA vlProductDA = new ProductDA();

            BrandBLL vlBrandBLL = new BrandBLL();
            List<Brand> vlLstBrand = piLstProduct.Select(x => x.Brand).ToList();

            vlBrandBLL.AddUniqueName(vlLstBrand);
            vlProductDA.Add(piLstProduct);
        }
    }
}
