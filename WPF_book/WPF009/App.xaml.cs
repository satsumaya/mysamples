using System;
using System.Windows;

namespace WPF009
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "Shop.db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DatabasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}
