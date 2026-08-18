using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TeamPiZAZCPW211TeamProject.Forms;

/// <summary>
/// A custom UserControl that combines a dropdown with a CheckedListBox, allowing multiple selections.
/// </summary>
/// <typeparam name="T">A type that represents the items in the dropdown.</typeparam>
public partial class MultiCheckDropdown<T> : UserControl
{
    // The panel that acts as the dropdown display area.
    private Panel displayPanel = new Panel();

    // The label that shows the selected items or a placeholder text.
    private Label displayLabel = new Label();

    // The CheckedListBox that contains the selectable items.
    private CheckedListBox clb = new CheckedListBox();

    // The popup form that appears when the dropdown is clicked.
    private Form popupForm = new Form();

    // Event that is triggered when the selection changes in the CheckedListBox.
    public event EventHandler SelectionChanged;

    // Initializes a new instance of the MultiCheckDropdown class.
    public MultiCheckDropdown()
    {
        this.Height = 25;
        this.Width = 100;
        this.BackColor = Color.FromArgb(35, 35, 35);
        this.BorderStyle = BorderStyle.FixedSingle;

        // Display panel (ComboBox look)
        displayPanel.Dock = DockStyle.Fill;
        displayPanel.BackColor = this.BackColor;

        // Label showing selected items
        displayLabel.Dock = DockStyle.Fill;
        displayLabel.ForeColor = Color.White;
        displayLabel.TextAlign = ContentAlignment.MiddleLeft;
        displayLabel.Padding = new Padding(6, 0, 0, 0);
        displayLabel.Text = "Select...";

        displayPanel.Controls.Add(displayLabel);
        this.Controls.Add(displayPanel);

        // Popup form setup
        popupForm.FormBorderStyle = FormBorderStyle.None;
        popupForm.StartPosition = FormStartPosition.Manual;
        popupForm.ShowInTaskbar = false;
        popupForm.BackColor = Color.FromArgb(40, 40, 40);

        // Checklist setup
        clb.BorderStyle = BorderStyle.None;
        clb.CheckOnClick = true;
        clb.ItemHeight = 22;
        clb.BackColor = Color.FromArgb(40, 40, 40);
        clb.ForeColor = Color.White;

        popupForm.Controls.Add(clb);

        // Open dropdown
        displayPanel.Click += OpenDropdown;
        displayLabel.Click += OpenDropdown;

        // Update display when items checked
        clb.ItemCheck += (s, e) =>
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                UpdateDisplayText();

                //Shout out to the main form that the selection has changed
                SelectionChanged?.Invoke(this, EventArgs.Empty);
            });
        };

        popupForm.Deactivate += (s, e) => popupForm.Hide();
    }

    private void OpenDropdown(object sender, EventArgs e)
    {
        AdjustDropdownHeight();   // calculate correct height first

        clb.Width = this.Width;

        // Force layout BEFORE showing the popup
        clb.PerformLayout();
        popupForm.PerformLayout();

        popupForm.Size = new Size(this.Width, clb.Height);

        Point location = this.Parent.PointToScreen(new Point(this.Left, this.Bottom));
        popupForm.Location = location;

        popupForm.Show();
        popupForm.BringToFront();

    }


    public void AddItem(T entity)
    {
        clb.Items.Add(entity);
        AdjustDropdownHeight();
    }

    private void AdjustDropdownHeight()
    {
        int itemCount = clb.Items.Count;
        int itemHeight = clb.ItemHeight;

        clb.ScrollAlwaysVisible = true;
        clb.IntegralHeight = false;

        // We need to cap the dropdown height so it remains usable on smaller screens.
        const int maxDropdownHeight = 200;
        int desiredHeight = itemCount * itemHeight;
        clb.Height = Math.Min(desiredHeight, maxDropdownHeight);

    }

    private void UpdateDisplayText()
    {
        var items = clb.CheckedItems.Cast<T>().ToList();

        if (items.Count == 0)
            displayLabel.Text = "Select...";
        else
            displayLabel.Text = string.Join(", ", items.Select(i => i.ToString()));
    }

    public List<T> CheckedItems =>
        clb.CheckedItems.Cast<T>().ToList();
}
