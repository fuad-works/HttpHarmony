namespace HttpHarmony
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            AddAddButtonTab();
            AddNewTab("New Request");
        }


        private void AddNewTab(string tabText)
        {
            // Create a new TabPage
            TabPage newTabPage = new TabPage(tabText);

            // Add controls to the new TabPage as needed
            TextBox textBox = new TextBox();
            textBox.Dock = DockStyle.Fill; // Fill the entire TabPage with the TextBox
            newTabPage.Controls.Add(textBox);

            // Add the new TabPage to the CloseableTabControl
            tabControl1.TabPages.Insert(tabControl1.TabCount - 1, newTabPage);
            tabControl1.SelectedTab = newTabPage;
        }

        private void AddAddButtonTab()
        {
            // Check if the "+" tab already exists
            if (tabControl1.TabPages.Count > 0 && tabControl1.TabPages[tabControl1.TabPages.Count - 1].Text == "+")
            {
                // If it exists, remove it temporarily
                tabControl1.TabPages.RemoveAt(tabControl1.TabPages.Count - 1);
            }

            // Create a new TabPage for the "+" button
            TabPage addButtonTabPage = new TabPage("+");

            // Add the new TabPage to the TabControl
            tabControl1.TabPages.Add(addButtonTabPage);

            // If the "+" tab was removed, add it back
            //if (tabControl1.TabPages.Count > 1)
            //{
                // Insert it at the second-to-last position (before the "+")
            //}

            // Select the last tab (the "+" tab)
           // tabControl1.SelectedTab = addButtonTabPage;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected tab is the "+" tab
            if (tabControl1.SelectedTab != null && tabControl1.SelectedTab.Text == "+")
            {
                // If it is, add a new tab and switch to it
                int newTabIndex = tabControl1.TabCount; // Get the index where the new tab will be added
                AddNewTab("New Request " + newTabIndex);
                //tabControl1.SelectedIndex = newTabIndex; // Switch to the new tab
            }
        }

    }
}
