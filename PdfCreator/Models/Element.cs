using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Web;
using System.IO;

namespace PdfCreator.Models
{
    public class Element
    {
        public int id { get; set; }
        public string name { get; set; }
        public int documentId { get; set; }
        public byte type { get; set; }
        public decimal x { get; set; }
        public decimal y { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }
        public string extension { get; set; }

        public virtual Document Document { get; set; }

        public string directoryPath { get { return HttpContext.Current.Server.MapPath("~\\App_Data\\DataFiles\\"); } }
        public string imagePath { get { return Path.Combine(directoryPath, id.ToString() + extension); } }

        public void saveFile(HttpPostedFileBase file)
        {
            string ext = Path.GetExtension(file.FileName);
            if (this.extension != null && this.extension != ext)
                this.removeFile();

            this.extension = ext;
            file.SaveAs(this.imagePath);
        }

        public void removeFile()
        {
            if (this.extension != null)
            {
                FileInfo file = new FileInfo(this.imagePath);
                file.Delete();
                this.extension = null;
            }
        }
    }


    public class ElementMapping : EntityTypeConfiguration<Element>
    {
        public ElementMapping()
            : base()
        {
            this.HasRequired(e => e.Document).WithMany(e => e.Elements).HasForeignKey(e => e.documentId);
        }
    }
}