﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfNetControlApp1.Controls
{
    /// <summary>
    /// このカスタム コントロールを XAML ファイルで使用するには、手順 1a または 1b の後、手順 2 に従います。
    ///
    /// 手順 1a) 現在のプロジェクトに存在する XAML ファイルでこのカスタム コントロールを使用する場合
    /// この XmlNamespace 属性を使用場所であるマークアップ ファイルのルート要素に
    /// 追加します:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfNetControlApp1.Conrols"
    ///
    ///
    /// 手順 1b) 異なるプロジェクトに存在する XAML ファイルでこのカスタム コントロールを使用する場合
    /// この XmlNamespace 属性を使用場所であるマークアップ ファイルのルート要素に
    /// 追加します:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfNetControlApp1.Conrols;assembly=WpfNetControlApp1.Conrols"
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
    ///     <MyNamespace:NumericUpDown/>
    ///
    /// </summary>
    [TemplatePart(Type = typeof(RepeatButton), Name = "PART_UpButton")]
    [TemplatePart(Type = typeof(RepeatButton), Name = "PART_DownButton")]
    [TemplateVisualState(GroupName = "PositiveNegative", Name = "Negative")]
    [TemplateVisualState(GroupName = "PositiveNegative", Name = "Positive")]
    public class NumericUpDown : Control
    {
        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(int),
                typeof(NumericUpDown),
                new PropertyMetadata(0, ValueChanged));

        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NumericUpDown)d).UpdateState(true);
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // XAMLで定義されたボタン格納用変数
        private RepeatButton upButton;

        private RepeatButton downButton;

        // ボタンのクリックイベント
        private void UpClick(object sender, RoutedEventArgs e)
        {
            this.Value++;
        }

        private void DownClick(object sender, RoutedEventArgs e)
        {
            this.Value--;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // 前のテンプレートのコントロールの後処理
            if (this.upButton != null)
            {
                this.upButton.Click -= this.UpClick;
            }
            if (this.downButton != null)
            {
                this.downButton.Click -= this.DownClick;
            }

            // テンプレートからコントロールの取得
            this.upButton = this.GetTemplateChild("PART_UpButton") as RepeatButton;
            this.downButton = this.GetTemplateChild("PART_DownButton") as RepeatButton;

            // イベントハンドラの登録
            if (this.upButton != null)
            {
                this.upButton.Click += this.UpClick;
            }
            if (this.downButton != null)
            {
                this.downButton.Click += this.DownClick;
            }

            // VSMの更新
            this.UpdateState(false);
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
