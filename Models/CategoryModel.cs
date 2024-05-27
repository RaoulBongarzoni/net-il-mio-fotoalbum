namespace net_il_mio_fotoalbum.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<PhotoModel> PhotosList {get ; set;}

        public CategoryModel() { }

        public CategoryModel(string _name, string _description) 
        {


            this.Name = _name;
            this.Description = _description;
                
                
        }
    }
}
