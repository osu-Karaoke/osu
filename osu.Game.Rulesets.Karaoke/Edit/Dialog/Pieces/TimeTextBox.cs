﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Framework.Input.Events;

namespace osu.Game.Rulesets.Karaoke.Edit.Dialog.Pieces
{
    /// <summary>
    ///     set the rule to change the input time format to --:--.--
    ///     osu.Game.Screens.Edit.Components : TimeInfoContainer.cs
    /// </summary>
    public class TimeTextBox : RevertableTextbox<double>
    {
        public override double OldValue
        {
            get => base.OldValue;
            set => base.OldValue = value;
        }

        public override double NewValue
        {
            get => base.NewValue;
            set => base.NewValue = value;
        }

        public TimeTextBox()
        {
            LengthLimit = 9;
            PlaceholderText = "00:00:000";
            Placeholder.FixedWidth = true;

            //update string to new format
            OnCommit += (a, isNewText) => { UpdateTextToFormat(); };
        }

        public override void ConvertOldValueToText()
        {
            UpdateTextToFormat();
            base.ConvertOldValueToText();
        }

        public override void ConvertTextToNewValue()
        {
            base.ConvertTextToNewValue();
            try
            {
                NewValue = double.Parse(Text);
                NewValue = NewValue * 1000;
            }
            catch
            {
            }
        }

        //start edit
        protected override void OnFocus(FocusEvent e)
        {
            //disable update new value
            IsSettingLodValue = true;

            //Convert double to text
            Text = HasEdited ? (NewValue / 1000).ToString() : (OldValue / 1000).ToString();

            base.OnFocus(e);
        }

        //EndEdit
        protected override void OnFocusLost(FocusLostEvent e)
        {
            base.OnFocusLost(e);
            UpdateTextToFormat();
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            IsSettingLodValue = false;
            return base.OnKeyDown(e);
        }

        #region Function

        //end edit
        protected void UpdateTextToFormat()
        {
            IsSettingLodValue = true;

            Text = DoubleToString(HasEdited ? NewValue : OldValue);
        }

        protected string DoubleToString(double time)
        {
            return TimeSpan.FromMilliseconds(time).ToString(@"mm\:ss\:fff");
        }

        protected double StringToDouble(string stringTime)
        {
            TimeSpan time;
            TimeSpan.TryParse(stringTime, out time);
            var milliSecond = time.TotalMilliseconds / 60;
            return milliSecond;
        }

        #endregion
    }
}
