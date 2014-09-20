using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MislakaInterface
{
    public enum FileTypes { TST = 1, DAT, PDF, JPG };
    public enum ServiceTypes { EVENTS, FEDBKA, FEDBKB, FEEDBK, HOLDNG, CONSLT, TRNSFR, WRNING, EMPONG, EMPNEG, EMPFED, EMPSVR, EMPYRL };
    public enum ProductTypes { KGM, PNN, PNO, INP, ING , NotRelevant };

    class MislakaFileName
    {
        private string direction;

        public string Direction // 3 chars
        {
            get { return direction; }
            set { direction = value; }
        }

        private string customerID;

        public string CustomerID // 12 chars
        {
            get { return customerID; }
            set { customerID = value; }
        }

        private ServiceTypes service; // 6 chars

        public ServiceTypes Service
        {
            get { return service; }
            set { service = value; }
        }

        private ProductTypes productType;

        public ProductTypes ProductType
        {
            get { return productType; }
            set { productType = value; }
        }
        
        private string version;

        public string Version // 3 chars
        {
            get { return version; }
            set { version = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private int sequence;

        public int Sequence // 4 chars
        {
            get { return sequence; }
            set { sequence = value; }
        }

        private FileTypes fileType;

        public FileTypes FileType // 3 chars
        {
            get { return fileType; }
            set { fileType = value; }
        }

        private int attachmentSequence = 0;

        public int AttachmentSequence 
        {
            get { return attachmentSequence; }
            set { attachmentSequence = value; }
        }

        public MislakaFileName(string Direction, string CustomerID, ServiceTypes Service, ProductTypes ProductType,
                       string Version, DateTime Date, int Sequence, int AttachmentSequence, FileTypes FileType)
        {
            direction = Direction;
            customerID = CustomerID;
            service = Service;
            productType = ProductType;
            version = Version;
            date = Date;
            sequence = Sequence;
            attachmentSequence = AttachmentSequence;
            fileType = FileType;

        }

        public MislakaFileName(string Direction, string CustomerID, ServiceTypes Service, ProductTypes ProductType, 
                               string Version, DateTime Date, int Sequence, FileTypes FileType)
        {
            direction = Direction;
            customerID = CustomerID;
            service = Service;
            productType = ProductType;
            version = Version;
            date = Date;
            sequence = Sequence;
            fileType = FileType;

        }

        public MislakaFileName(string FileName)
        {
            direction = FileName.Substring(0, 3);
            customerID = FileName.Substring(3, 12);
            string x = FileName.Substring(15, 6);
            service = (ServiceTypes)Enum.Parse(typeof(ServiceTypes), FileName.Substring(15, 6));
                
            if (FileName.Substring(21, 3) != "000")
                productType = (ProductTypes)Enum.Parse(typeof(ProductTypes), FileName.Substring(21, 3));
            else
                productType = ProductTypes.NotRelevant;

            version = FileName.Substring(24, 3);
            date = (DateTime)Common.ConvertDatetime(FileName.Substring(27, 14));
            sequence = Convert.ToInt32(FileName.Substring(41, 4));
            fileType = (FileTypes)Enum.Parse(typeof(FileTypes), FileName.Substring(46, 3));
        }

        public string GetMislakaFileName ()
        {
            string FileName;
            string prodType = productType.ToString();
            string attSequence = "";

            if (attachmentSequence > 0)
            {
                attSequence = "_" + attachmentSequence.ToString("000");
            }

            if (productType == ProductTypes.NotRelevant)
                prodType = "000";

            FileName = direction +
                       CustomerID.PadLeft(12,'0') +
                       service.ToString() +
                       prodType +
                       version +
                       date.ToString("yyyyMMddHHmmss") +
                       sequence.ToString("0000") + 
                       attSequence +
                       "." + 
                       fileType.ToString();
            return FileName;
        }
    }
}
