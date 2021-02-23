using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.calculator = new Calculator();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Привет");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.SelectionStart = 0;
            this.AccuracyBox.SelectedIndex = 3;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void buttEqual_Click(object sender, EventArgs e)
        {
            outExpration = this.calculator.GetResult(textBox1.Text);
            if (!outExpration.Equals("Err"))
            {
                textBox1.Text = outExpration;
                this.textBox1.SelectionLength = 0;
                this.textBox1.SelectionStart = outExpration.Length;
            }
            else
            {
                textBox1.ForeColor = System.Drawing.Color.Firebrick;
                timer1.Start();
            }
           
        }

        private void butSave_Click_1(object sender, EventArgs e)
        {
            calculator.SavedNumber = textBox1.Text;
            calculator.CalcClear();
        }
        private void butExtract_Click(object sender, EventArgs e)
        {
            InsertText(calculator.SavedNumber);
        }
        private void butClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void InsertText(string text)
        {
            //this.textBox1.Focus();
            int temp = this.textBox1.SelectionStart;
            this.textBox1.Text = this.textBox1.Text.Insert(this.textBox1.SelectionStart, text);
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = temp +  text.Length;
        }
        private void num1_Click(object sender, EventArgs e)
        {
            InsertText("1");
        }

        private void num2_Click(object sender, EventArgs e)
        {
            InsertText("2");
        }


        private void num3_Click(object sender, EventArgs e)
        {
            InsertText("3");

        }

        private void num4_Click(object sender, EventArgs e)
        {  
            InsertText("4");
        }

        private void num5_Click(object sender, EventArgs e)
        {  
            InsertText("5");

        }

        private void num6_Click(object sender, EventArgs e)
        {  
            InsertText("6");

        }

        private void num7_Click(object sender, EventArgs e)
        { 
            InsertText("7");

        }

        private void num8_Click(object sender, EventArgs e)
        {  
            InsertText("8");

        }

        private void num9_Click(object sender, EventArgs e)
        { 
            InsertText("9");

        }

        private void num0_Click(object sender, EventArgs e)
        {  
            InsertText("0");

        }

       

        private void buttPoint_Click(object sender, EventArgs e)
        {  
            InsertText(",");

        }

        private void buttPlus_Click(object sender, EventArgs e)
        {  
            InsertText("+");

        }

        private void buttMinus_Click(object sender, EventArgs e)
        {  
            InsertText("-");

        }

        private void buttStar_Click(object sender, EventArgs e)
        {  
            InsertText("*");

        }

        private void buttDirslash_Click(object sender, EventArgs e)
        {  
            InsertText("/");

        }
        private void butSin_click(object sender, EventArgs e)
        {  
            InsertText(calculator.SinStr + "(");

        }

        

        private void butCos_Click(object sender, EventArgs e)
        { 
            InsertText(calculator.CosStr + "(");

        }

        private void butTg_Click(object sender, EventArgs e)
        {  
            InsertText(calculator.TgStr + "(");

        }

        private void butCtg_Click(object sender, EventArgs e)
        {  
            InsertText(calculator.CtgStr + "(");

        }

        private void buttRoot2_Click(object sender, EventArgs e)
        {  
            InsertText(calculator.Root2Str + "(");

        }

        private void buttRoot3_Click(object sender, EventArgs e)
        {  
            InsertText(calculator.Root3Str + "(");

        }
        private void butPow2_Click(object sender, EventArgs e)
        {  
            InsertText(calculator.Pow2Str + "(");

        }

       

        private void butPow3_Click(object sender, EventArgs e)
        {  
            InsertText(calculator.Pow3Str + "(");

        }

        private void buttLeft_Click(object sender, EventArgs e)
        {  
            InsertText("(");

        }

        private void buttRight_Click(object sender, EventArgs e)
        {  
            InsertText(")");

        }

        private void buttDel_Click(object sender, EventArgs e)
        {
            int temp = this.textBox1.SelectionStart;
            if (this.textBox1.Text.Length == 0 || temp == 0) return;
            
            this.textBox1.Text =  this.textBox1.Text.Remove(temp - 1, 1);
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = temp - 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void KeyPress_Click(object sender, KeyPressEventArgs e)
        {   
            if ((int)e.KeyChar == (int)Keys.Enter) 
            {
                buttEqual_Click(sender, e);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.Color.SlateGray;

        }

        private void AccuracySelected(object sender, EventArgs e)
        {
            calculator.AccuracyMode = AccuracyBox.SelectedIndex + 1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
