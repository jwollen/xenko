﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using SiliconStudio.Core.Storage;
using SiliconStudio.Core.Serialization.Serializers;

namespace SiliconStudio.Core.Serialization.Assets
{
    [DataContract]
    [DataSerializer(typeof(ObjectUrl.Serializer))]
    public struct ObjectUrl : IEquatable<ObjectUrl>
    {
        public static readonly ObjectUrl Empty = new ObjectUrl(UrlType.None, string.Empty);

        public readonly UrlType Type;
        public readonly string Path;

        public ObjectUrl(UrlType type, string path)
        {
            if (path == null)
                throw new ArgumentException("path");

            Type = type;
            Path = path;
        }

        public bool Equals(ObjectUrl other)
        {
            return Type == other.Type && string.Equals(Path, other.Path);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ObjectUrl && Equals((ObjectUrl)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)Type * 397) ^ Path.GetHashCode();
            }
        }

        public static bool operator ==(ObjectUrl left, ObjectUrl right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ObjectUrl left, ObjectUrl right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return Path;
        }

        internal class Serializer : DataSerializer<ObjectUrl>
        {
            public override void Serialize(ref ObjectUrl obj, ArchiveMode mode, SerializationStream stream)
            {
                if (mode == ArchiveMode.Serialize)
                {
                    stream.Write(obj.Type);
                    stream.Write(obj.Path);
                }
                else
                {
                    var type = stream.Read<UrlType>();
                    var path = stream.ReadString();
                    obj = new ObjectUrl(type, path);
                }
            }
        }
    }
}