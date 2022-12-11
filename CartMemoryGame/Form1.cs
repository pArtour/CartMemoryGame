using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CartMemoryGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k", "a", "a", "e", "e", "v", "v", "x", "x"
        };


        Label firstClick, secondClick;



        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void labelClick(object sender, EventArgs e)
        {
            if (firstClick != null && secondClick != null)
            {
                return;
            }

            Label clickedLabel = sender as Label;


            if (clickedLabel == null)
            {
                return;
            }
            if (clickedLabel.ForeColor == Color.Black)
            {
                return;
            }
            if (firstClick == null)
            {
                firstClick = clickedLabel;
                firstClick.ForeColor = Color.Black;
                return;
            }
            secondClick = clickedLabel;
            secondClick.ForeColor = Color.Black;

            CheckForWinner();

            if (firstClick.Text == secondClick.Text)
            {
                firstClick = null;
                secondClick = null;

            }
            else
            {
                timer1.Start();
            }
            
        }

        private void CheckForWinner()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                
                if (label != null && label.ForeColor == label.BackColor)
                {
                    return;
                }
            }

            MessageBox.Show("You win! Congratulations!");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClick.ForeColor = Color.LightBlue;
            secondClick.ForeColor = Color.LightBlue;

            firstClick = null;
            secondClick = null;

        }

        private void AssignIconsToSquares()
        {
            Label label;
            int randomNum;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i];
                }
                else
                {
                    continue;
                }
                randomNum = random.Next(0, icons.Count);
                label.Text = icons[randomNum];

                icons.RemoveAt(randomNum);

            }
        }
    }
}