namespace _2535502_Akhmetov;
using SQLite;
public class SQLiteService : IDbService{

    public SQLiteConnection db_authors;
    public SQLiteConnection db_books;
    private string db_name1 = "authors.db";
    private string db_name2 = "books.db";


    public SQLiteService(){
        string path1 = Path.Combine (
        Environment.GetFolderPath (Environment.SpecialFolder.LocalApplicationData),
        db_name1);
        string path2 = Path.Combine (
        Environment.GetFolderPath (Environment.SpecialFolder.LocalApplicationData),
        db_name2);
        
        db_authors = new SQLiteConnection(path1);
        db_books = new SQLiteConnection(path2);
        db_authors.CreateTable<Author>();
        db_books.CreateTable<Book>();
    }


    public IEnumerable<Author> GetAllAuthors(){
        return db_authors.Table<Author>().ToList();
    }
    

    public IEnumerable<Book> GetAuthorsBooks(int id){
        var tmp = new List<Book>();
        foreach(var i in db_books.Table<Book>()){
            if(i.AuthorsId == id){
                tmp.Add(i);
            }

        }
        return new List<Book>();
    }
    

    public void Init(){
        
        List<string> auth = new List<string>{"Толстой", "Достоевский", "Чехов"};
        List<string> Tolstoy = new List<string>{"Война и мир", "Анна Каренина", "Детство", "Посое бала", "Воскресение", "Отрочество", "Юность"};
        List<string> Dost = new List<string>{"Преступление и наказание", "Братья Карамазовы", "Белые ночи", "Бесы", "Игрок", "Подросток", "Двойник"};
        List<string> Cheh = new List<string>{"Хамелеон", "Толстый и тонкий", "Тоска", "О любви", "Пари", "Ванька", "Злоумышленник"};
        
        foreach(var author in auth){
            var tmp = new Author();
            tmp.name = author;
            db_authors.Insert(tmp);
        }

        foreach(var i in db_authors.Table<Author>().ToList()){
            if(i.name == "Толстой"){
                foreach(var j in Tolstoy){
                    var tmp = new Book();
                    tmp.BookName = j;
                    tmp.AuthorsId = i.id;
                    db_books.Insert(tmp);
                }
            }
            if(i.name == "Достоевский"){
                foreach(var j in Dost){
                    var tmp = new Book();
                    tmp.BookName = j;
                    tmp.AuthorsId = i.id;
                    db_books.Insert(tmp);
                }
            }
            if(i.name == "Чехов"){
                foreach(var j in Cheh){
                    var tmp = new Book();
                    tmp.BookName = j;
                    tmp.AuthorsId = i.id;
                    db_books.Insert(tmp);
                }
            }
        }
    }




}