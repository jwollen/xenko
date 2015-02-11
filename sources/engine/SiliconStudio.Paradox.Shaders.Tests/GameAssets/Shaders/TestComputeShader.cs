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

namespace SiliconStudio.Paradox.Effects
{
    public static partial class TestComputeShaderKeys
    {
        public static readonly ParameterKey<Vector3> ThreadGroupCountGlobal = ParameterKeys.New<Vector3>();
        public static readonly ParameterKey<uint> ParticleCount = ParameterKeys.New<uint>();
        public static readonly ParameterKey<uint> ParticleStartIndex = ParameterKeys.New<uint>();
        public static readonly ParameterKey<Buffer> ParticleSortBuffer = ParameterKeys.New<Buffer>();
        public static readonly ParameterKey<Buffer> ParticleSortBufferRO = ParticleSortBuffer;
    }
}
