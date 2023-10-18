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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCustomButtonApp1
{
    /// <summary>
    /// このカスタム コントロールを XAML ファイルで使用するには、手順 1a または 1b の後、手順 2 に従います。
    ///
    /// 手順 1a) 現在のプロジェクトに存在する XAML ファイルでこのカスタム コントロールを使用する場合
    /// この XmlNamespace 属性を使用場所であるマークアップ ファイルのルート要素に
    /// 追加します:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfCustomButtonApp1"
    ///
    ///
    /// 手順 1b) 異なるプロジェクトに存在する XAML ファイルでこのカスタム コントロールを使用する場合
    /// この XmlNamespace 属性を使用場所であるマークアップ ファイルのルート要素に
    /// 追加します:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfCustomButtonApp1;assembly=WpfCustomButtonApp1"
    ///
    /// また、XAML ファイルのあるプロジェクトからこのプロジェクトへのプロジェクト参照を追加し、
    /// リビルドして、コンパイル エラーを防ぐ必要があります:
    ///
    ///     ソリューション エクスプローラーで対象のプロジェクトを右クリックし、
    ///     [参照の追加] の [プロジェクト] を選択してから、このプロジェクトを参照し、選択します。
    ///
    ///
    /// 手順 2)
    /// コントロールを XAML ファイルで使用します。
    ///
    ///     <MyNamespace:MaterialDesignButton/>
    ///
    /// </summary>
    public class MaterialDesignButton : Button
    {
        static MaterialDesignButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaterialDesignButton), new FrameworkPropertyMetadata(typeof(MaterialDesignButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Ellipse ellipse = GetTemplateChild("PART_effectRipple") as Ellipse;
            Grid grid = GetTemplateChild("PART_grid") as Grid;
            Storyboard animation = grid.FindResource("RippleAnimation") as Storyboard;

            this.AddHandler(MouseDownEvent, new RoutedEventHandler((sender, e) =>
            {
                // マウス座標を取得します。
                var mousePosition = (e as MouseButtonEventArgs).GetPosition(this);
                var startMargin = new Thickness(mousePosition.X, mousePosition.Y, 0, 0);
                // まずは、マウス座標をアニメーションの起点とします。
                ellipse.Margin = startMargin;

                // だんだんと、Effectコントロール大きくなるようなアニメーションを設定します。
                // 大きくなる最大幅はボタンの幅の2倍のサイズを定義しています。
                var maxWidth = Math.Max(ActualWidth, ActualHeight) * 2;
                DoubleAnimation sizeUpAnimation = animation.Children[0] as DoubleAnimation;
                sizeUpAnimation.To = maxWidth;

                // アニメーション開始と同時に、Effectコントロールの中心位置を移動します。
                // Effectのサイズが大きくなる(sizeUpAnimation)につれ、中心位置がズレていくためズレを修正するための中心位置の補正を行っています。
                ThicknessAnimation centerPositionMovingAnimation = animation.Children[1] as ThicknessAnimation;
                centerPositionMovingAnimation.From = startMargin;
                centerPositionMovingAnimation.To = new Thickness(mousePosition.X - maxWidth / 2, mousePosition.Y - maxWidth / 2, 0, 0);

                // アニメーションを開始します。
                ellipse.BeginStoryboard(animation);
            }), true);
        }
    }
}
