using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Memory_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _LoadImage();
        }

      
        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
        }
       
        public int Counter = 0;
        public DataTable dtImage;
        private Button button1_Image;
        private Button button2_Image;

        private async Task  CheckEquelImage(Button btn)
        {
            if ((button1_Image == null) && (button2_Image == null))
            {
                button1_Image = btn;
            }
            else 
            {
                button2_Image = btn;
                if (button1_Image.Tag.ToString() == button2_Image.Tag.ToString())
                {
                    button2_Image.BackColor = Color.Lime;
                    button1_Image.BackColor = Color.Lime;

                    await Task.Delay(500);

                    button1_Image.Enabled = false;
                    button2_Image.Enabled = false;

                    button2_Image.BackColor = Color.White;
                    button1_Image.BackColor = Color.White;
                    Counter += 2;
                    if (Counter == 16)
                    {
                        MessageBox.Show("Game Over ", "Win");
                    }

                }
                else
                {
                    button1_Image.BackColor = Color.Red;
                    button2_Image.BackColor = Color.Red;

                    await Task.Delay(1000); // بدل Sleep
                    CloseImage(button1_Image);
                    CloseImage(button2_Image);
                    
                }
                button1_Image = null;
                button2_Image = null;
            }

        }

        private void _LoadImage()
        {
            List<Button> btnImage = new List<Button> {btn1,btn2, btn3, btn4, btn5, btn6
                                                     , btn7, btn8, btn9, btn10, btn11, btn12
                                                       ,btn13,btn14,btn15,btn16};

            dtImage = ClassBusiness.GetAllImage();

            int i = 0;
            foreach (Button btn in btnImage)
            {
                btn.Tag = (int)dtImage.Rows[i]["ID"];
                //MessageBox.Show(btn.Tag.ToString()+"   <= btn " + (i+1).ToString());
                i++;
            }
        }
        private void ShowImage(Button btn)
        {
            if (button1_Image != null && button2_Image != null)
            {
                return;
            }
            int id = Convert.ToInt32(btn.Tag); // هنا Tag بساوي ID
            DataRow[] rows = dtImage.Select("ID = " + id);

            if (rows.Length > 0)
            {
                string path = rows[0]["ImagePath"].ToString();
                btn.BackgroundImage = Image.FromFile(path);
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.Text = null;
                
            }
            CheckEquelImage(btn);
        }
        private void CloseImage(Button btn)
        {
            btn.BackColor = Color.White;
            btn.BackgroundImage = Properties.Resources.Card2;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            //btn.Text = "?";
        }
        private void ResetImage(Button btn)
        {
            //btn.Text = "?";
            CloseImage(btn);
            btn.Enabled = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //MessageBox.Show($"Tag :{btn.Tag}");
            ShowImage(btn);
        }
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            ResetImage(btn1);
            ResetImage(btn2);
            ResetImage(btn3);
            ResetImage(btn4);
            ResetImage(btn5);
            ResetImage(btn6);
            ResetImage(btn7);
            ResetImage(btn8);
            ResetImage(btn9);
            ResetImage(btn10);
            ResetImage(btn11);
            ResetImage(btn12);
            ResetImage(btn13);
            ResetImage(btn14);
            ResetImage(btn15);
            ResetImage(btn16);
            Counter = 0;
            button1_Image = null;
            button2_Image = null;
            _LoadImage();
        }
    }
}
