﻿// <auto-generated>
// Do not edit this file yourself!
//
// This code was generated by Paradox Shader Mixin Code Generator.
// To generate it yourself, please install SiliconStudio.Paradox.VisualStudio.Package .vsix
// and re-save the associated .pdxfx.
// </auto-generated>

using System;
using SiliconStudio.Core;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Paradox.Graphics;
using SiliconStudio.Paradox.Shaders;
using SiliconStudio.Core.Mathematics;
using Buffer = SiliconStudio.Paradox.Graphics.Buffer;

namespace PostEffects
{
    [DataContract]public partial class PostEffectsParameters : ShaderMixinParameters
    {
        public static readonly ParameterKey<bool> verticalBlur = ParameterKeys.New<bool>();
    };
    internal static partial class ShaderMixins
    {
        internal partial class VerticalVsmBlur  : IShaderMixinBuilder
        {
            public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
            {
                context.SetParam(PostEffectsParameters.verticalBlur, true);
                context.Mixin(mixin, "PostEffectVsmBlur", context.GetParam(PostEffectsParameters.verticalBlur));
            }

            [ModuleInitializer]
            internal static void __Initialize__()

            {
                ShaderMixinManager.Register("VerticalVsmBlur", new VerticalVsmBlur());
            }
        }
    }
    internal static partial class ShaderMixins
    {
        internal partial class HorizontalVsmBlur  : IShaderMixinBuilder
        {
            public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
            {
                context.SetParam(PostEffectsParameters.verticalBlur, false);
                context.Mixin(mixin, "PostEffectVsmBlur", context.GetParam(PostEffectsParameters.verticalBlur));
            }

            [ModuleInitializer]
            internal static void __Initialize__()

            {
                ShaderMixinManager.Register("HorizontalVsmBlur", new HorizontalVsmBlur());
            }
        }
    }
}
