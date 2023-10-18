using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfUserControlsApp1
{
    /// <summary>
    /// NumericUpDown.xaml の相互作用ロジック
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        /// <summary>
        /// NumericUpDownの値を保持するためのValue依存関係プロパティを
        /// NumericUpDownコントロールに作成します。
        /// 
        /// 
        /// コードビハインドで、VisualStateの切り替え処理を書きます。
        /// VisualStateの切り替えは、VisualStateManager.GoToStateメソッドを使います。
        /// GoToStateメソッドは、VisualStateを切り替えるコントロールと、
        /// VisualState名と、VisualStateが切り替わるときの
        /// アニメーション効果を使用するかどうかを設定します。
        /// Valueプロパティの値が書き換わったタイミングでVisualStateを切り替えればいいので
        /// 以下のようなコードになります。
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(int),
                typeof(NumericUpDown),
                new PropertyMetadata(0, ValueChanged));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NumericUpDown)d).UpdateState(true);
        }

        public NumericUpDown()
        {
            InitializeComponent();
            this.UpdateState(false);
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            this.Value++;
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            this.Value--;
        }

        private void UpdateState(bool useTransition)
        {
            if (this.Value >= 0)
            {
                VisualStateManager.GoToState(this, "Positive", useTransition);
            }
            else
            {
                VisualStateManager.GoToState(this, "Negative", useTransition);
            }
        }
    }
}
