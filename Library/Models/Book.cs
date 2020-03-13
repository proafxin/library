using Library.CustomAttributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [BsonElement("Authors")]
        [Required]
        public String Authors { get; set; }

        [BsonElement("Title")]
        [Required]
        public String Title { get; set; }

        [BsonElement("CoverUrl")]
        [Required]
        [Display(Name ="Cover")]
        [DataType(DataType.ImageUrl)]
        public String CoverUrl { get; set; }

        [BsonElement("Thumbnail")]
        [Display(Name ="Thumbnail")]
        [DataType(DataType.ImageUrl)]
        public String ThumbNail { get; set; }

        [BsonElement("Year")]
        [Required]
        public int Year { get; set; }

        [BsonElement("Language")]
        [Required]
        public String Language { get; set; }

        [BsonElement("Pages")]
        [Required]
        public int Pages { get; set; }

        [BsonElement("ISBN10")]
        [Required]
        public String ISBN10 { get; set; }

        [BsonElement("ISBN13")]
        [Required]
        public String ISBN13 { get; set; }

        [BsonElement("Edition")]
        public int? Edition { get; set; }

        [BsonElement("DownloadLink")]
        [Display(Name ="Download link")]
        [DataType(DataType.Url)]
        public String DownloadUrl { get; set; }
    }
}
