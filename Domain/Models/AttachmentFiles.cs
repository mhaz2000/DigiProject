using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    /// <summary>
    /// فایل ضمیمه
    /// </summary>
    public class AttachmentFile
    {
        public AttachmentFile()
        {
            Id = Guid.NewGuid();
            LastModified = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public string MimeType { get; set; }
        public bool IsPhysicalStorage { get; set; }
        public bool IsBinaryStorage { get; set; }
        public byte[] Binary { get; set; }
        public string PhysicalPath { get; set; }
        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
        public Guid? PosterImageGuid { get; set; }
        public ICollection<Commodity> Commodities { get; set; }
        
    }
}

