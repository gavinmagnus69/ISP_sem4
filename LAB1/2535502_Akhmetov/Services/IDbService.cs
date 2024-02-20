namespace _2535502_Akhmetov;



public interface IDbService{
    IEnumerable<Author> GetAllAuthors();
    IEnumerable<Book> GetAuthorsBooks(int id);
    void Init();   
}