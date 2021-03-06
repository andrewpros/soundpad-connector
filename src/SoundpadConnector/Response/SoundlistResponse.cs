﻿using System.IO;
using System.Text;
using System.Xml.Serialization;
using SoundpadConnector.XML;

namespace SoundpadConnector.Response
{
    /// <summary>
    ///     Represents a <see cref="Soundlist"/> response
    /// </summary>
    public class SoundlistResponse : ResponseBase<Soundlist>
    {
        /// <inheritdoc />
        public override void Parse(string response)
        {
            if (response.StartsWith("R")) {
                ErrorMessage = response;
                IsSuccessful = false;
            }
            var deserializer = new XmlSerializer(typeof(Soundlist));
            var resultStream = new MemoryStream(Encoding.UTF8.GetBytes(response));
            Value = (Soundlist)deserializer.Deserialize(resultStream);
            IsSuccessful = true;
        }
    }
}
