namespace _2535502_Akhmetov;
using SQLite;

[Table("Books")]
public class Book{
[PrimaryKey, AutoIncrement, Indexed]
    public int BookID {get; set;}
    [MaxLength(30)]
    public string BookName {get; set;}
    [Indexed]
    public int AuthorsId {get; set;}
};