using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
namespace WebSite.Models
{
    public class LUTOLD
    {
        private Repository _repository = new Repository();
        private List<DAL.LUT> lut;

       
        public List<DAL.LUT> Lut
        {
            get { return lut; }
        }

        public LUTOLD()
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

    public class LUT
    {
        private struct LUTKey {
            public string ColumnName;
            public int Code;
        }

        private Repository _repository = new Repository();
        private Dictionary<LUTKey, string> lut = new Dictionary<LUTKey, string>();
        private List<DAL.LUT> lutList;

        public LUT ()
        {
            LUTKey codeValue;
            lutList = _repository.GetLUT();
            string value;
            foreach (DAL.LUT lutElement in lutList)
            {
                codeValue = new LUTKey();
                codeValue.ColumnName = lutElement.ColumnName;
                codeValue.Code = lutElement.Code;

                if (!lut.TryGetValue(codeValue, out value)) 
                    lut.Add(codeValue, lutElement.Value);               
            }
        }

        //public string Get(string tableName, string columnName, int? code)
        //{
        //    if (code == null)
        //        code = 0;

        //    string value = lut.First(item => item.TableName == tableName && item.ColumnName == columnName && item.Code == code).Value;

        //    return value;
        //}

        public string Get(string columnName, int? code)
        {
            string value;
            if (code == null)
                code = 0;

            LUTKey key = new LUTKey();
            key.ColumnName = columnName;
            key.Code = (int)code;
            try
            {
                value = lut[key];
                return value;
            }
            catch 
            {
                return "";
            }
        }
    
    }
}