using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace NUI_tests_svg
{
    class Program : NUIApplication
    {
        static string _imageUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";

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
            _visualView.Size2D = new Size2D(650, 950);
            _visualView.ParentOrigin = ParentOrigin.Center;
            _visualView.PositionUsesPivotPoint = true;
            _visualView.PivotPoint = PivotPoint.Center;

            SVGVisual _svgVisual = new SVGVisual();
            _svgVisual.URL = _imageUrl + "tiger.svg";
            _svgVisual.Origin = Visual.AlignType.BottomEnd;
            _svgVisual.AnchorPoint = Visual.AlignType.BottomEnd;
            _svgVisual.RelativeSize = new RelativeVector2(0.5f,0.5f);

            _visualView.AddVisual("SVG-Image", _svgVisual);

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
