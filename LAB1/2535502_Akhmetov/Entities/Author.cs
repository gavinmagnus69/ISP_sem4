using SQLite;
namespace _2535502_Akhmetov;

[Table("Authors")]
public class Author{
    [PrimaryKey, AutoIncrement, Indexed]
    public int id {get; set;}
    [MaxLength(20)]
    public string name {get; set;}
};

