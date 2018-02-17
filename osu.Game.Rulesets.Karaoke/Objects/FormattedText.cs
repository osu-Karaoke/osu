﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using Newtonsoft.Json;
using OpenTK;
using osu.Game.Rulesets.Karaoke.Objects.Types;
using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Rulesets.Karaoke.Objects
{
    /// <summary>
    /// Text objects
    /// </summary>
    public class FormattedText : TextComponent, IHasPosition
    {
        // <inheritdoc />
        /// <summary>
        /// if template !=null will relative to template's position
        /// else, will be absolute position
        /// </summary>
        public Vector2 Position { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// X position
        /// </summary>
        [JsonIgnore]
        public float X
        {
            get => Position.X;
            set => Position = new Vector2(value, Y);
        }

        /// <inheritdoc />
        /// <summary>
        /// Y position
        /// </summary>
        [JsonIgnore]
        public float Y
        {
            get => Position.Y;
            set => Position = new Vector2(X, value);
        }

       

        /// <summary>
        /// size of the font
        /// </summary>
        public virtual int? FontSize { get; set; }

        /// <summary>
        /// operator
        /// </summary>
        /// <param name="object1"></param>
        /// <param name="object2"></param>
        /// <returns></returns>
        public static FormattedText operator +(FormattedText object1, FormattedText object2)
        {
            if (object1 == null && object2 == null)
                return null;

            if (object1 == null)
                return object2;

            if (object2 == null)
                return object1;

            return new FormattedText()
            {
                Position = object1.Position + object2.Position,
                Text = object1.Text + object2.Text,
                FontSize = object2?.FontSize ?? object1.FontSize,
            };
        }

        /// <summary>
        /// cast from string to FormattedText
        /// </summary>
        /// <param name="textObject"></param>
        public static explicit operator FormattedText(string textObject)
        {
            return new FormattedText()
            {
                Text = textObject,
            };
        }

        public static FormattedText FromText(string textObject)
        {
            return new FormattedText()
            {
                Text = textObject,
            };
        }

        public static FormattedText FromText(TextComponent textObject)
        {
            return new FormattedText()
            {
                Text = textObject?.Text,
            };
        }
    }
}
