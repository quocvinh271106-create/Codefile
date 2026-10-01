using System.Drawing;
namespace aaaa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily f in FontFamily.Families)
            {
                cmbFont.Items.Add(f.Name);
            }

            cmbSize.Items.Add("8");
            cmbSize.Items.Add("9");
            cmbSize.Items.Add("10");
            cmbSize.Items.Add("11");
            cmbSize.Items.Add("12");
            cmbSize.Items.Add("14");
            cmbSize.Items.Add("16");
            cmbSize.Items.Add("18");
            cmbSize.Items.Add("20");
            cmbSize.Items.Add("22");
            cmbSize.Items.Add("24");
            cmbSize.Items.Add("26");
            cmbSize.Items.Add("28");
            cmbSize.Items.Add("36");
            cmbSize.Items.Add("48");
            cmbSize.Items.Add("72");

            cmbFont.Text = "Tahoma";
            cmbSize.Text = "14";

            richTextBox1.Font = new Font("Tahoma", 14);
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            cmbFont.Text = "Tahoma";
            cmbSize.Text = "14";

            richTextBox1.Font = new Font("Tahoma", 14);
        }

        private void mởTệpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "Rich Text Format (*.rtf)|*.rtf|Text File (*.txt)|*.txt";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (openFile.FileName.EndsWith(".rtf"))
                    richTextBox1.LoadFile(openFile.FileName);
                else
                    richTextBox1.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "Rich Text Format (*.rtf)|*.rtf|Text File (*.txt)|*.txt";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (saveFile.FileName.EndsWith(".rtf"))
                {
                    richTextBox1.SaveFile(saveFile.FileName);
                }
                else
                {
                    richTextBox1.SaveFile(
                        saveFile.FileName,
                        RichTextBoxStreamType.PlainText
                    );
                }

                MessageBox.Show("Lưu văn bản thành công!");
            }

        }

        private void cmbFont_Click(object sender, EventArgs e)
        {
            {
                if (cmbFont.SelectedItem != null)
                {
                    string fontName = cmbFont.SelectedItem.ToString();

                    if (richTextBox1.SelectionLength > 0)
                    {
                        richTextBox1.SelectionFont = new Font(
                            fontName,
                            richTextBox1.SelectionFont.Size,
                            richTextBox1.SelectionFont.Style
                        );
                    }
                    else
                    {
                        richTextBox1.Font = new Font(
                            fontName,
                            richTextBox1.Font.Size,
                            richTextBox1.Font.Style
                        );
                    }
                }
            }
        }

        private void cmbSize_Click(object sender, EventArgs e)
        {
            if (cmbSize.SelectedItem != null)
            {
                float size = float.Parse(cmbSize.SelectedItem.ToString());

                if (richTextBox1.SelectionLength > 0)
                {
                    richTextBox1.SelectionFont = new Font(
                        richTextBox1.SelectionFont.FontFamily,
                        size,
                        richTextBox1.SelectionFont.Style
                    );
                }
                else
                {
                    richTextBox1.Font = new Font(
                        richTextBox1.Font.FontFamily,
                        size,
                        richTextBox1.Font.Style
                    );
                }
            }
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Font currentFont = richTextBox1.SelectionFont;

                FontStyle newStyle;

                if (currentFont.Bold)
                    newStyle = currentFont.Style & ~FontStyle.Bold;
                else
                    newStyle = currentFont.Style | FontStyle.Bold;

                richTextBox1.SelectionFont = new Font(
                    currentFont,
                    newStyle
                );
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Font currentFont = richTextBox1.SelectionFont;

                FontStyle newStyle;

                if (currentFont.Italic)
                    newStyle = currentFont.Style & ~FontStyle.Italic;
                else
                    newStyle = currentFont.Style | FontStyle.Italic;

                richTextBox1.SelectionFont = new Font(
                    currentFont,
                    newStyle
                );
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Font currentFont = richTextBox1.SelectionFont;

                FontStyle newStyle;

                if (currentFont.Underline)
                    newStyle = currentFont.Style & ~FontStyle.Underline;
                else
                    newStyle = currentFont.Style | FontStyle.Underline;

                richTextBox1.SelectionFont = new Font(
                    currentFont,
                    newStyle
                );
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.SelectionFont;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }
    }
}

