using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;

namespace WingetRepoBrowser
{
	public class GridRowPopupMenuBehavior
	{
		private readonly GridView _view;
		private DXMenuItem[] _menuItems=[];


		public GridRowPopupMenuBehavior(GridView view)
		{
			if (view == null)
			{
				throw new ArgumentNullException(nameof(view), $"{nameof(view)} is null.");
			}

			_view = view;

			_view.PopupMenuShowing += view_PopupMenuShowing;
		}

		public void SetMenuItems(DXMenuItem[] menuItems)
		{
			if (menuItems == null)
			{
				throw new ArgumentNullException(nameof(menuItems), $"{nameof(menuItems)} is null.");
			}
			_menuItems = menuItems;
		}

		private void view_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
		{
			FillPopupMenuItems(sender, e, _menuItems);
		}

		public static void FillPopupMenuItems(object sender, PopupMenuShowingEventArgs e, DXMenuItem[] menuItems)
		{
			if (e.HitInfo.InDataRow) // 'InRow' is true in AutoFilterRow!
			{
				GridView view = (GridView)sender;
				view.FocusedRowHandle = e.HitInfo.RowHandle;
				if (menuItems == null)
				{
					return;
				}
				if (e.Menu == null)
				{
					// this occurs when the click was exactly on the vertical separating line between columns
					//Trace.WriteLine(nameof(MainForm.FillPopupMenuItems) + " e.Menu is null");
					return;
				}

				foreach (DXMenuItem item in menuItems)
				{
					e.Menu.Items.Add(item);
				}
			}
		}


	}


}
