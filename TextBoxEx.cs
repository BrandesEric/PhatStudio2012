using System;
using System.Windows.Forms;

namespace PhatStudio
{
	/// <summary>
	/// When a TextBoxEx receives focus, 
	/// all text in the textbox is selected.
	/// </summary>
	public class TextBoxEx : TextBox
	{
		private bool alreadyFocused;

		public TextBoxEx()
		{
		}

		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);

			alreadyFocused = false;
		}


		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);

			// Select all text only if the mouse isn't down.
			// This makes tabbing to the textbox give focus.
			if (MouseButtons == MouseButtons.None)
			{
				SelectAll();
				alreadyFocused = true;
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			// Web browsers like Google Chrome select the text on mouse up.
			// They only do it if the textbox isn't already focused,
			// and if the user hasn't selected all text.
			if (!alreadyFocused && SelectionLength == 0)
			{
				alreadyFocused = true;
				SelectAll();
			}
		}
	}
}
