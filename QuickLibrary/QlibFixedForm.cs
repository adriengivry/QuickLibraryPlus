﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibFixedForm : Form
	{
		[Browsable(false), Obsolete("Don't use this! (FormBorderStyle = None)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum FormBorderStyle { };

		[Browsable(false), Obsolete("Don't use this! (AutoScaleMode = Dpi)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScaleMode { };

		[Browsable(false), Obsolete("Don't use this! (HelpButton = false)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum HelpButton { };
		[Browsable(false), Obsolete("Don't use this! (AutoScroll = false)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScroll { };

		[Browsable(false), Obsolete("Don't use this! (AutoScrollMargin = [0, 0])", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScrollMargin { };

		[Browsable(false), Obsolete("Don't use this! (AutoScrollMinSize = [0, 0])", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScrollMinSize { };

		[Browsable(false), Obsolete("Don't use this! (AutoSize = false)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoSize { };

		[Browsable(false), Obsolete("Don't use this! (AutoSizeMode = GrowAndShrink)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoSizeMode { };

		[Browsable(false), Obsolete("Don't use this! (BackgroundImage = None)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum BackgroundImage { };

		[Browsable(false), Obsolete("Don't use this! (BackgroundImageLayout = Tile)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum BackgroundImageLayout { };

		[Browsable(false), Obsolete("Don't use this! (Font = ThemeManager.DefaultFont)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum Font { };

		private bool m_aeroEnabled;
		public bool draggable = false;

		//private const int CS_DROPSHADOW = 0x00020000;
		//private const int WM_NCPAINT = 0x0085;

		//[System.Runtime.InteropServices.DllImport("dwmapi.dll")]
		//public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
		//[System.Runtime.InteropServices.DllImport("dwmapi.dll")]
		//public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
		//[System.Runtime.InteropServices.DllImport("dwmapi.dll")]

		//public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
		//[System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

		//private static extern IntPtr CreateRoundRectRgn(
		//	int nLeftRect,
		//	int nTopRect,
		//	int nRightRect,
		//	int nBottomRect,
		//	int nWidthEllipse,
		//	int nHeightEllipse
		//);

		//public struct MARGINS
		//{
		//	public int leftWidth;
		//	public int rightWidth;
		//	public int topHeight;
		//	public int bottomHeight;
		//}

		//protected override CreateParams CreateParams
		//{
		//	get
		//	{
		//		m_aeroEnabled = CheckAeroEnabled();
		//		CreateParams cp = base.CreateParams;
		//		if (!m_aeroEnabled)
		//			cp.ClassStyle |= CS_DROPSHADOW;
		//		return cp;
		//	}
		//}

		public const int WS_SYSMENU = 0x80000;
		public const int CS_DROPSHADOW = 0x20000;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				//cp.Style = WS_SYSMENU;
				cp.ClassStyle |= CS_DROPSHADOW;
				return cp;
			}
		}

		//private bool CheckAeroEnabled()
		//{
		//	if (Environment.OSVersion.Version.Major >= 6)
		//	{
		//		int enabled = 0;
		//		DwmIsCompositionEnabled(ref enabled);
		//		return (enabled == 1) ? true : false;
		//	}
		//	return false;
		//}

		//protected override void WndProc(ref Message m)
		//{
		//	switch (m.Msg)
		//	{
		//		case WM_NCPAINT:
		//			if (m_aeroEnabled)
		//			{
		//				var v = 2;
		//				DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
		//				MARGINS margins = new MARGINS()
		//				{
		//					bottomHeight = -1,
		//					leftWidth = 0,
		//					rightWidth = 0,
		//					topHeight = 0
		//				};
		//				DwmExtendFrameIntoClientArea(this.Handle, ref margins);
		//			}
		//			break;
		//		default: break;
		//	}
		//	base.WndProc(ref m);
		//}

		public QlibFixedForm() 
		{
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.HelpButton = false;
			base.AutoScroll = false;
			base.AutoScrollMargin = new System.Drawing.Size(0, 0);
			base.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			base.AutoSize = false;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			base.BackgroundImage = null;
			base.BackgroundImageLayout = ImageLayout.Tile;
			base.Font = ThemeManager.DefaultFont;

			m_aeroEnabled = !ThemeManager.isWindows10();
		}

		public void SetDraggableControls(List<Control> controls)
		{
			foreach (Control control in controls)
			{
				control.MouseDown += Control_MouseDown;
			}
		}

		private void Control_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				GoDrag();
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (e.Button == MouseButtons.Left && draggable)
			{
				GoDrag();
			}
		}

		private void GoDrag()
		{
			Cursor.Current = Cursors.SizeAll;
			NativeMethodsManager.ReleaseCapture();
			NativeMethodsManager.SendMessage(Handle, 0xA1, 0x2, 0);
		}
	}
}