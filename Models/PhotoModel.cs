﻿using net_il_mio_fotoalbum.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{

    [Table("Photos")]
    public class PhotoModel
    {
        [Key]public int Id { get; set; }

        
        public string Title { get; set; }

        public string? Description { get; set; }

        public bool Visible {  get; set; }

        //aggiungere categorie
        public List<CategoryModel>? CategoriesList { get; set; }

        //gestione immagini
        public byte[] ImgFile { get; set; }

        public string ImgSrc => ImgFile != null ? $"data:image/png; base64, {Convert.ToBase64String(ImgFile)}" : "";



        //costruttore vuoto
        public PhotoModel( ) { }


        public PhotoModel(string _title, string? _description, bool _visibility = true)
        {
            this.Title = _title;
            this.Description = _description;

            this.Visible = _visibility;
        }

    }
}
