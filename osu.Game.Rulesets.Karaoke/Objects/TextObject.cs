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
    public class TextObject : IHasText , IHasPosition
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
        /// text
        /// </summary>
        public virtual string Text { get; set; }

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
        public static TextObject operator +(TextObject object1, TextObject object2)
        {
            if (object1 == null && object2 == null)
                return null;

            if (object1 == null)
                return object2;

            if (object2 == null)
                return object1;

            return new TextObject()
            {
                Position = object1.Position + object2.Position,
                Text = object1.Text + object2.Text,
                FontSize = object2?.FontSize ?? object1.FontSize,
            };
        }

        /// <summary>
        /// cast from string to TextObject
        /// </summary>
        /// <param name="textObject"></param>
        public static explicit operator TextObject(string textObject)
        {
            return new TextObject()
            {
                Text = textObject,
            };
        }
    }
}
