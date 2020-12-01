using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace NUI_tests_align
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;
            Window.Instance.BackgroundColor = Color.Black;

            View _mainView = new View();
            _mainView.Size2D = Window.Instance.WindowSize;
            Window.Instance.Add(_mainView);

            VisualView _visualView = new VisualView();
            _visualView.BackgroundColor = new Color(0.88f, 0.88f, 0.88f, 1.0f);
            _visualView.Size2D = new Size2D(650, 900);
            _visualView.ParentOrigin = ParentOrigin.Center;
            _visualView.PositionUsesPivotPoint = true;
            _visualView.PivotPoint = PivotPoint.Center;

            ColorVisual _colorVisual = new ColorVisual();
            _colorVisual.Color = Color.Red;
            _colorVisual.Size = new Size2D(400,400);

            _visualView.AddVisual("color_visual", _colorVisual);

            _mainView.Add(_visualView);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "Escape" ||
                e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "BackSpace"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
