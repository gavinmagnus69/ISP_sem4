namespace _2535502_Akhmetov;

using System.Diagnostics;
using System.Linq.Expressions;
using SQLite;


public partial class SQLiteDemo : ContentPage
{

    public SQLiteDemo(){
        
        InitializeComponent();
        try{
            var serviceProvider = MauiProgram.services.BuildServiceProvider();
            MauiProgram.dbService = serviceProvider.GetService<IDbService>();
            MauiProgram.dbService.Init();
            foreach(var i in MauiProgram.dbService.GetAllAuthors()){
                 this.authors.Items.Add(i.name);
                 //Debug.WriteLine($"xxxxxxxxxxxxxxxxxxx:{i.name}, {tmp.Count}");
                 
            }
            // authors.ItemsSource = tmp; 
        }
        catch(Exception e){
            Debug.WriteLine("error bebra --------------> {0}" ,e.Message);
        }
    }





}