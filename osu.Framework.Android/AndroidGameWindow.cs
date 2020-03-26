﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Configuration;
using osuTK.Graphics;
using System.Collections.Generic;
using osuTK;
using GameWindow = osu.Framework.Platform.GameWindow;

namespace osu.Framework.Android
{
    public class AndroidGameWindow : GameWindow
    {
        public override IGraphicsContext Context
            => View.GraphicsContext;

        internal static AndroidGameView View;

        public override bool Focused
            => true;

        public override osuTK.WindowState WindowState
        {
            get => osuTK.WindowState.Normal;
            set { }
        }

        public AndroidGameWindow()
            : base(View)
        {
        }

        public override void SetupWindow(FrameworkConfigManager config)
        {
            // Let's just say the cursor is always in the window.
            CursorInWindow = true;
        }

        protected override IEnumerable<WindowMode> DefaultSupportedWindowModes => new[]
        {
            Configuration.WindowMode.Fullscreen,
        };

        public override void Run()
        {
            View.Run();
        }

        public override void Run(double updateRate)
        {
            View.Run(updateRate);
        }

        public override DisplayDevice CurrentDisplayDevice
        {
            get => DisplayDevice.Default;
            set => throw new InvalidOperationException();
        }
    }
}
