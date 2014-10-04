using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
namespace WebSite.Models
{
    public class LUT
    {
        private Repository _repository = new Repository();
        private List<DAL.LUT> lut;

        public List<DAL.LUT> Lut
        {
            get { return lut; }
        }

        public LUT ()
        {
            lut = _repository.GetLUT();
        }

        public string Get(string tableName, string columnName, int? code)
        {
            if (code == null)
                code = 0;

            string value = lut.First(item => item.TableName == tableName && item.ColumnName == columnName && item.Code == code).Value;

            return value;
        }

        public string Get(string columnName, int? code)
        {
            if (code == null)
                code = 0;

            string value;

            try
            {
                value = lut.First(item => item.ColumnName == columnName && item.Code == code).Value;
            }
            catch
            {
                value = "";    
            }
            return value;
        }

    }
}