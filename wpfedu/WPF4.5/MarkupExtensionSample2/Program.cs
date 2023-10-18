namespace MarkupExtensionSample2
{
    using System;
    using System.Windows.Markup;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // XAMLを読み込んでIdを表示
            var item = XamlReader.Load(
                typeof(Program).Assembly.GetManifestResourceStream("MarkupExtensionSample2.Item.xaml")) as Item;
            Console.WriteLine(item.Id);

            // 再度XAMLを読み込んでIdを表示
            var item2 = XamlReader.Load(
                typeof(Program).Assembly.GetManifestResourceStream("MarkupExtensionSample2.Item.xaml")) as Item;
            Console.WriteLine(item2.Id);
        }
    }
}
