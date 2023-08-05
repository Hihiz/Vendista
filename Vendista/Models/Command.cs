namespace Vendista.Models
{
    public class Command
    {
        public int page_number { get; set; }
        public int items_per_page { get; set; }
        public int items_count { get; set; }
        public List<CommandType> items { get; set; }
        public bool success { get; set; }      
    }
}
