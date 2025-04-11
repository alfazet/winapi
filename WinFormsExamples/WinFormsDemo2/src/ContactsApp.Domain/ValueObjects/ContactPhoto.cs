using System;
using System.Collections.Generic;
using System.IO;
using ContactsApp.Domain.Shared;

namespace ContactsApp.Domain.ValueObjects
{
    public class ContactPhoto : ValueObject<ContactPhoto>
    {
        public enum PhotoType
        {
            Unknown = 0,
            Jpeg = 1,
            Gif = 2,
            Png = 3
        }
        private byte[] _rawData;
        public byte[] Image => _rawData;

        public PhotoType Type { get; }

        public string Size => BytesHelper.BytesToString(_rawData?.Length ?? 0);

        public ContactPhoto(byte[] rawData, PhotoType photoType)
        {
            _rawData = rawData ?? throw new ArgumentNullException(nameof(rawData));
            Type = photoType;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Size;
            yield return Image;
        }

        public override string ToString()
        {
            return $"Image of type {Type} and size {Size}.";
        }

        public static PhotoType TypeFromFileName(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return PhotoType.Unknown;
            switch (Path.GetExtension(filePath).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return PhotoType.Jpeg;
                case ".png":
                    return PhotoType.Png;
                case ".gif":
                    return PhotoType.Gif;
                default:
                    return PhotoType.Unknown;
            }

        }
    }
}
