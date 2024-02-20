namespace _2535502_Akhmetov;

using System.Linq.Expressions;
using SQLite;


public partial class SQLiteDemo : ContentPage
{


    SQLiteService sql;
    public SQLiteDemo(){
        try{
            sql = new SQLiteService();
            var tmp = new List<String>();
            foreach(var i in sql.GetAllAuthors()){
                tmp.Add(i.name);
                 
            }
            authors.ItemsSource = tmp; 
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        InitializeComponent();
    }





}