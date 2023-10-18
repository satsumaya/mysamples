# README

WPF4.5入門 その54 「カスタムコントロール」

https://blog.okazuki.jp/entry/2014/09/08/221209


UserControlで、独自コントロールを作る方法を紹介しましたが、
UserControlではできないことがあります。
ControlTemplateへ対応です。

ControlTemplateへ対応した完全なWPFの独自コントロールを作るには、
これから紹介するカスタムコントロールを作成する必要があります。

カスタムコントロールは、新規作成のカスタムコントロール（WPF）から作成します。
作成すると、クラスが1つとThemesフォルダの中にGeneric.xamlが作成されます。
このGeneric.xaml内にコントロールのデフォルトのStyleを定義してコントロールを作成します。

コントロールのデフォルトのStyleのキーはクラスの静的コンストラクタで
以下のようにDefaultStyleKey依存関係プロパティのデフォルト値を上書きすることで指定されています。

```c#
static NumericUpDown()
{
    DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), 
new FrameworkPropertyMetadata(typeof(NumericUpDown)));
}
```
