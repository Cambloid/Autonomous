namespace Autonomous.Editor
{
    public partial class Editor : Form
    {



        public Editor()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                var res = dlg.ShowDialog();
                if (res == DialogResult.OK)
                {

                    Tokenizer t = new Tokenizer(dlg.FileName);

                    TokenReader reader = new TokenReader(t.GetTokens());

                    IncludeSearcher searcher = new IncludeSearcher(reader);


                    foreach (string item in searcher.GetIncludes())
                    {
                        this.listView1.Items.Add(item);
                    }



                }
            }
        }
    }
}