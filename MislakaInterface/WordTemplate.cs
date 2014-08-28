using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.Reflection;
//using Word = Microsoft.Office.Interop.Word;
using System.Drawing.Drawing2D;


namespace MislakaInterface
{
    class WordTemplate
    {

        private static Application wordApp = new Application();
        private static Document wordDoc = new Document();
        private Object oMissing = System.Reflection.Missing.Value;

        public void FillAndSave(string name, string id, string address, string templateFileName, string PdfFileName)
        {
            //OBJECT OF MISSING "NULL VALUE"

            Object oTemplatePath = templateFileName;

            wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
            foreach (Field myMergeField in wordDoc.Fields)
            {
                Range rngFieldCode = myMergeField.Code;
                String fieldText = rngFieldCode.Text;

                myMergeField.Select();
                if (fieldText.StartsWith("Name"))
                    wordApp.Selection.TypeText(name);

                if (fieldText.StartsWith("Id"))
                    wordApp.Selection.TypeText(id);

                if (fieldText.StartsWith("Address"))
                    wordApp.Selection.TypeText(address);

            }

            object outputPDFFileNameObj = PdfFileName;
            System.IO.File.Delete(PdfFileName);

            object fileFormat = WdSaveFormat.wdFormatPDF;
            // Save document into PDF Format
            wordDoc.SaveAs(ref outputPDFFileNameObj,
                ref fileFormat, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            //To save into word format:           
            //wordDoc.SaveAs(@"c:\users\lior\Documents\myfile3.docx");

        }
        ~WordTemplate ()
        {
            wordApp.Application.Quit(ref oMissing, ref oMissing, ref oMissing);
        }
    }
}
