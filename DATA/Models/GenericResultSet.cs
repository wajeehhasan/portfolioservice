
namespace DATA.Models
{
    
    public class GenericResultSet<T>
    {
        public bool status { get; set; } = true;
        public string message { get; set; } = "Operaiton Successful";
        public T resultSet { get; set; }
    }
}
