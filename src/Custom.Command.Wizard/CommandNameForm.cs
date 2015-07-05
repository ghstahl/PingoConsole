using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom.Command.Wizard
{
    public partial class CommandNameForm : Form
    {
        public string CommandName { get; private set; }
        private const string StrRegex = @"^[a-zA-Z][a-zA-Z0-9]{1,24}";
        private static readonly Regex Pattern = new Regex(StrRegex, RegexOptions.IgnoreCase);

        public CommandNameForm()
        {
            InitializeComponent();
            buttonDone.Enabled = false;
        }
        private void buttonDone_Click(object sender, EventArgs e)
        {
            CommandName = textBoxName.Text;
            Close();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonDone.Enabled = Pattern.IsMatch(textBoxName.Text);
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}
