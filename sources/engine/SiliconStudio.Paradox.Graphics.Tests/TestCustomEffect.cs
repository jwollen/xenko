﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System.Threading.Tasks;
using NUnit.Framework;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Rendering;
using SiliconStudio.Paradox.Games;
using SiliconStudio.Paradox.Graphics.Internals;

namespace SiliconStudio.Paradox.Graphics.Tests
{
    public static class MyCustomShaderKeys
    {
        public static readonly ParameterKey<Vector4> ColorFactor2 = ParameterKeys.New<Vector4>();
    }

    [TestFixture]
    public class TestCustomEffect : TestGameBase
    {
        private ParameterCollection effectParameters;
        private DynamicEffectCompiler dynamicEffectCompiler;

        private DefaultEffectInstance effectInstance;

        private float switchEffectLevel;

        private EffectParameterCollectionGroup parameterCollection;

        public TestCustomEffect()
        {
            CurrentVersion = 1;
        }

        protected override void RegisterTests()
        {
            base.RegisterTests();

            FrameGameSystem.Draw(DrawCustomEffect).TakeScreenshot();
        }

        protected override async Task LoadContent()
        {
            await base.LoadContent();


            dynamicEffectCompiler = new DynamicEffectCompiler(Services, "CustomEffect.CustomSubEffect");
            effectParameters = new ParameterCollection();
            effectInstance = new DefaultEffectInstance(effectParameters);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            if(!ScreenShotAutomationEnabled)
                DrawCustomEffect();
        }

        private void DrawCustomEffect()
        {
            GraphicsDevice.Clear(GraphicsDevice.BackBuffer, Color.Black);
            GraphicsDevice.Clear(GraphicsDevice.DepthStencilBuffer, DepthStencilClearOptions.DepthBuffer);
            GraphicsDevice.SetDepthAndRenderTarget(GraphicsDevice.DepthStencilBuffer, GraphicsDevice.BackBuffer);

            effectParameters.Set(MyCustomShaderKeys.ColorFactor2, (Vector4)Color.Red);
            effectParameters.Set(CustomShaderKeys.SwitchEffectLevel, switchEffectLevel);
            effectParameters.Set(TexturingKeys.Texture0, UVTexture);
            switchEffectLevel++; // TODO: Add switch Effect to test and capture frames
            dynamicEffectCompiler.Update(effectInstance, null);
            parameterCollection = new EffectParameterCollectionGroup(GraphicsDevice, effectInstance.Effect, new[] { effectParameters });

            GraphicsDevice.DrawQuad(effectInstance.Effect, parameterCollection);
        }

        public static void Main()
        {
            using (var game = new TestCustomEffect())
                game.Run();
        }

        /// <summary>
        /// Run the test
        /// </summary>
        [Test]
        public void RunCustomEffect()
        {
            RunGameTest(new TestCustomEffect());
        }
    }
}