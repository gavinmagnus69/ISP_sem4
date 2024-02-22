namespace _2535502_Akhmetov;

using System.Diagnostics;
using System.Linq.Expressions;
using SQLite;


public partial class SQLiteDemo : ContentPage
{

    public SQLiteDemo(){
            InitializeComponent();
            var serviceProvider = MauiProgram.services.BuildServiceProvider();
            MauiProgram.dbService = serviceProvider.GetService<IDbService>();
            MauiProgram.dbService.Init();
            foreach(var i in MauiProgram.dbService.GetAllAuthors()){
                 this.authors.Items.Add(i.name);
            }
    }
    public void OnPickerIndexChanged(object sender, EventArgs e){
        int id = 0;
        foreach(var i in MauiProgram.dbService.GetAllAuthors()){
            if(i.name == authors.Items[authors.SelectedIndex]){
                id = i.id;
            }
        }
        var selected_books = MauiProgram.dbService.GetAuthorsBooks(id).Select(x => x.BookName).ToList();
         myCollectionView.ItemsSource = selected_books;

    }





}