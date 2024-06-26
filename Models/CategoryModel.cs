﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace net_il_mio_fotoalbum.Models
{
    [Table("Categories")]
    public class CategoryModel
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }

        public List<PhotoModel>? PhotosList {get ; set;}

        public CategoryModel() { }

        public CategoryModel(string _name) 
        {


            this.Name = _name;
           
        }
    }
}
