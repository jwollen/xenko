﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.

using System;
using System.Collections.Generic;

using SiliconStudio.Paradox.Graphics.Data;

namespace SiliconStudio.Paradox.Graphics.Font
{
    /// <summary>
    /// A font factory initializing only the data members of font. 
    /// Used when creating a font in the only purpose use serializing on disk.
    /// </summary>
    public class FontDataFactory : IFontFactory
    {
        public SpriteFont NewStatic(float size, IList<Glyph> glyphs, IList<Texture> textures, float baseOffset, float defaultLineSpacing, IList<Kerning> kernings = null, float extraSpacing = 0, float extraLineSpacing = 0, char defaultCharacter = ' ')
        {
            if (textures == null) throw new ArgumentNullException("textures");

            return new StaticSpriteFont(size, glyphs, textures, baseOffset, defaultLineSpacing, kernings, extraSpacing, extraLineSpacing, defaultCharacter);
        }

        public SpriteFont NewStatic(float size, IList<Glyph> glyphs, IList<Image> images, float baseOffset, float defaultLineSpacing, IList<Kerning> kernings = null, float extraSpacing = 0, float extraLineSpacing = 0, char defaultCharacter = ' ')
        {
            // creates the textures from the images if any.
            Texture[] textures = null;
            if (images != null)
            {
                textures = new Texture[images.Count];
                for (int i = 0; i < textures.Length; i++)
                    textures[i] = images[i].ToSerializableVersion();
            }
            
            return new StaticSpriteFont(size, glyphs, textures, baseOffset, defaultLineSpacing, kernings, extraSpacing, extraLineSpacing, defaultCharacter);
        }

        public SpriteFont NewDynamic(float defaultSize, string fontName, FontStyle style, FontAntiAliasMode antiAliasMode, bool useKerning, float extraSpacing, float extraLineSpacing, char defaultCharacter)
        {
            return new DynamicSpriteFont
            {
                Size = defaultSize,
                DefaultCharacter = defaultCharacter,
                FontName = fontName,
                ExtraLineSpacing = extraLineSpacing,
                ExtraSpacing = extraSpacing,
                Style = style,
                UseKerning = useKerning,
                AntiAlias = antiAliasMode,
            };
        }
    }
}