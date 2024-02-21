namespace _2535502_Akhmetov;

using System.Data.SqlTypes;
using System.Diagnostics;
using SQLite;
public class SQLiteService : IDbService{

    private SQLiteConnection db;

    private string db_name1 = "default.db";
   

    public SQLiteService(){

        SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
        string path1 = Path.Combine (
        Environment.GetFolderPath (Environment.SpecialFolder.LocalApplicationData), db_name1);
        db = new SQLiteConnection(path1);
    }


    public IEnumerable<Author> GetAllAuthors(){
        return db.Table<Author>().ToList();
    }
    

    public IEnumerable<Book> GetAuthorsBooks(int id){
        return db.Table<Book>().Where(x => x.AuthorsId == id).ToList();
    }
    

    public void Init(){

        db.CreateTable<Author>();
        db.CreateTable<Book>();
        
        List<string> auth = new List<string>{"Толстой", "Достоевский", "Чехов"};
        List<string> Tolstoy = new List<string>{"Война и мир", "Анна Каренина", "Детство", "Посое бала", "Воскресение", "Отрочество", "Юность"};
        List<string> Dost = new List<string>{"Преступление и наказание", "Братья Карамазовы", "Белые ночи", "Бесы", "Игрок", "Подросток", "Двойник"};
        List<string> Cheh = new List<string>{"Хамелеон", "Толстый и тонкий", "Тоска", "О любви", "Пари", "Ванька", "Злоумышленник"};
        
        foreach(var i in auth){
            var tmp = new Author();
            tmp.name = i;
            db.Insert(tmp);
        }

        foreach(var i in db.Table<Author>().ToList()){
            if(i.name == "Толстой"){
                foreach(var j in Tolstoy){
                    var tmp = new Book();
                    tmp.BookName = j;
                    tmp.AuthorsId = i.id;
                    db.Insert(tmp);
                }
            }
            if(i.name == "Достоевский"){
                foreach(var j in Dost){
                    var tmp = new Book();
                    tmp.BookName = j;
                    tmp.AuthorsId = i.id;
                    db.Insert(tmp);
                }
            }
            if(i.name == "Чехов"){
                foreach(var j in Cheh){
                    var tmp = new Book();
                    tmp.BookName = j;
                    tmp.AuthorsId = i.id;
                    db.Insert(tmp);
                }
            }
        }
    }




}