using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PublishingSystem.UI.Helpers // Or any suitable namespace
{
    public static class DataGridViewSortHelper
    {
        // These dictionaries will now be managed per DataGridView instance passed to the Sort method.
        // We'll use a way to associate them with the DataGridView, perhaps using the Tag property or
        // by making the calling form responsible for holding its own state dictionaries if preferred.

        // For simplicity, let's have the helper manage its own state for DataGridViews it has sorted.
        // This makes the calling code cleaner.
        private static readonly Dictionary<DataGridView, SortOrder> _sortOrders = new Dictionary<DataGridView, SortOrder>();
        private static readonly Dictionary<DataGridView, string> _lastSortedColumnNames = new Dictionary<DataGridView, string>();

        public static void HandleColumnHeaderMouseClick(DataGridView dgv, DataGridViewCellMouseEventArgs e)
        {
            if (dgv == null || dgv.Columns.Count == 0 || e.ColumnIndex < 0 || e.ColumnIndex >= dgv.Columns.Count)
                return;

            DataGridViewColumn newClickedColumn = dgv.Columns[e.ColumnIndex];
            string propertyName = newClickedColumn.DataPropertyName;

            if (string.IsNullOrEmpty(propertyName))
            {
                Console.WriteLine($"Cannot sort column '{newClickedColumn.Name}' as it has no DataPropertyName.");
                if (_lastSortedColumnNames.TryGetValue(dgv, out string previousSortedColumnName) && !string.IsNullOrEmpty(previousSortedColumnName))
                {
                    if (dgv.Columns.Contains(previousSortedColumnName))
                    {
                        dgv.Columns[previousSortedColumnName].HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                _lastSortedColumnNames[dgv] = null;
                _sortOrders.Remove(dgv);
                return;
            }

            SortOrder direction;
            _lastSortedColumnNames.TryGetValue(dgv, out string lastSortedColumnName);

            if (lastSortedColumnName == newClickedColumn.Name)
            {
                direction = _sortOrders.TryGetValue(dgv, out SortOrder currentOrder) && currentOrder == SortOrder.Ascending
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                direction = SortOrder.Ascending;
                if (!string.IsNullOrEmpty(lastSortedColumnName) && dgv.Columns.Contains(lastSortedColumnName))
                {
                    dgv.Columns[lastSortedColumnName].HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }

            _sortOrders[dgv] = direction;
            _lastSortedColumnNames[dgv] = newClickedColumn.Name;

            try
            {
                if (dgv.DataSource is System.Collections.IEnumerable dataSourceEnum)
                {
                    var list = dataSourceEnum.Cast<object>().ToList();
                    if (!list.Any()) return;

                    var propertyInfo = list.First().GetType().GetProperty(propertyName);
                    if (propertyInfo == null)
                    {
                        Console.WriteLine($"Property '{propertyName}' not found for sorting.");
                        return;
                    }

                    if (direction == SortOrder.Ascending)
                    {
                        list = list.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
                    }
                    else
                    {
                        list = list.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();
                    }

                    object selectedItem = null;
                    if (dgv.CurrentRow != null && dgv.CurrentRow.DataBoundItem != null)
                    {
                        selectedItem = dgv.CurrentRow.DataBoundItem;
                    }
                    int firstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex > -1 ? dgv.FirstDisplayedScrollingRowIndex : 0;


                    dgv.DataSource = null;
                    dgv.DataSource = list;

                    if (dgv.Columns.Contains(newClickedColumn.Name))
                    {
                        dgv.Columns[newClickedColumn.Name].HeaderCell.SortGlyphDirection = direction;
                    }

                    if (selectedItem != null)
                    {
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            if (dgv.Rows[i].DataBoundItem == selectedItem)
                            {
                                dgv.ClearSelection();
                                dgv.Rows[i].Selected = true;
                                int cellColumnIndex = (e.ColumnIndex >= 0 && e.ColumnIndex < dgv.Columns.Count) ? e.ColumnIndex : (dgv.Columns.Count > 0 ? 0 : -1);
                                if (cellColumnIndex != -1 && dgv.Rows[i].Cells.Count > cellColumnIndex) // Ensure cell exists
                                {
                                   dgv.CurrentCell = dgv.Rows[i].Cells[cellColumnIndex];
                                }
                                break;
                            }
                        }
                    }
                     if (firstDisplayedScrollingRowIndex >=0 && firstDisplayedScrollingRowIndex < dgv.Rows.Count)
                    {
                        dgv.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                    }
                }
                else
                {
                    Console.WriteLine("DataSource is not IEnumerable or null, manual sorting not applied.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during sort: {ex.Message}", "Sort Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dgv.Columns.Contains(newClickedColumn.Name))
                {
                    dgv.Columns[newClickedColumn.Name].HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
        }
    }
}