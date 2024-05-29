using System.ComponentModel.DataAnnotations;
namespace net_il_mio_fotoalbum.Models
{

    public class MessageModel
    {
        [Key]public int Id { get; set; }
        public string SentBy { get; set; }
        public string Text { get; set; }
        public DateTime Data {  get; set; } = DateTime.Now;

        public MessageModel()
        {

        }

        public MessageModel(string sender, string message)
        {
            SentBy = sender;
            Text = message;

        }
    }
}
