using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace PdfCreator.Models
{
    public class Document
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }

        public virtual ICollection<Element> Elements { get; set; }
    }

    public class DocumentMapping : EntityTypeConfiguration<Document>
    {
        public DocumentMapping()
            : base()
        {
            this.HasMany(e => e.Elements).WithRequired(e => e.Document).HasForeignKey(e => e.documentId);
        }
    }
}